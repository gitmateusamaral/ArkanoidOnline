<?php

if(!empty($_GET["act"]))
{
	$servername = "localhost";
	$username = "root";
	$password = "toor";
	$dbname = "arkanoid";

	// Create connection
	$conn = mysqli_connect($servername, $username, $password, $dbname);

	// Check connection
	if (!$conn) {
		die("ERROR: Connection failed. <br>" . mysqli_connect_error());
	}
	
	switch($_GET["act"])
	{
		case "get_score":
			if(!empty($_POST["user"]))
			{
				$user = htmlspecialchars($_POST["user"]);
				
				$sql = "SELECT * FROM `ranking` WHERE `user` = '" . $user . "'";
				$result = mysqli_query($conn, $sql);

				if (mysqli_num_rows($result) > 0) {
					// output data of each row
					while($row = mysqli_fetch_assoc($result)) {
						echo $row["score"]. ";";
					}
				}
				else
					echo "-1";
			}
			else
				echo "ERROR: Missing arguments";
			break;
		case "set_score":
			if(!empty($_POST["user"]) && !empty($_POST["score"]))
			{
				$user = htmlspecialchars($_POST["user"]);
				$score = htmlspecialchars($_POST["score"]);
				
				$sql = "SELECT `id` FROM `ranking` WHERE `user` = '" . $user . "'";
				$result = mysqli_query($conn, $sql);
				if(mysqli_num_rows($result) <= 0)
				{
					$sql = "INSERT INTO `ranking` (`user`, `score`) VALUES ('" . $user . "', " . $score . ")";
					$result = mysqli_query($conn, $sql);
				}
				else
				{
					$sql = "UPDATE `ranking` SET score=" . $score . " WHERE `user` = '" . $user . "'";
					$result = mysqli_query($conn, $sql);
				}
			}
			else
				echo "ERROR: Missing arguments";
			break;
		case "get_ranking":
				$sql = "SELECT * FROM `ranking` ORDER BY `score` DESC LIMIT 5";
				$result = mysqli_query($conn, $sql);

				if (mysqli_num_rows($result) > 0) {
					// output data of each row
					while($row = mysqli_fetch_assoc($result)) {
						echo $row["user"] . "&" . $row["score"]. ";";
					}
				}
			break;
		default:
			echo "ERROR: Invalid service";
			break;
	}
	
	mysqli_close($conn);
}
else
	echo "Hi! The page you is looking for was not found.";

?>
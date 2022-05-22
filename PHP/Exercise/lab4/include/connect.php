
<?php 
if (!defined("BASE_URL"))
{
    define("BASE_URL","https://jhalasan1.dmitstudent.ca/DMIT2025/lab4/");
}
$server = "localhost";
$username = "jhalasan1";
$password = "Blessor30";
$database = "jhalasan1";

$conn = new mysqli($server, $username, $password, $database);

if ($conn->connect_error) {
    die("Connection failed: " . $connect_error);
}
// else {
//     echo "conection good";
// }
?>
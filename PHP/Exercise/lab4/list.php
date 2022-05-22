<?php 

    $page_title = "List Management";

include ("include/header.php");
?>

<h2>List Page</h2>
<?php 
 $list_sql = "SELECT * From Course";

 $list_result = $conn->query($list_sql);
while ($row = $list_result->fetch_assoc())
{
    $code = $row['course_code'];
    $name = $row['course_name'];
    $desc = $row['course_desc'];
    echo "<div > ";
    echo "<h2 class=\"list\">$code $name</h2>";

    echo "<p class=\"description\">$desc</p>";
    echo "</div>";
}
?>

<?php 
include ("include/footer.php");
?>
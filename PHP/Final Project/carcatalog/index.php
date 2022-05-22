<?php 
session_start();
$page_title = "home";
include "inc/connect.php";
if (isset($_GET))
{
    extract($_GET);
}

 include 'login-post.php';
 include 'add-post.php';
 include 'view-details.php';
 
if (isset($_GET['carid']))
{
    $carid = $_GET['carid'];
    $user_id = $_SESSION['user_id'];
    $get_one_sql = "SELECT car_name, Manufacturer, Years, Type_of_car, Made, Base_engine_type, Engine_size, Drive_type, Total_seating, Estimated_Price, Cylinders, Descriptions, images FROM car WHERE carid = $carid AND user_id = $user_id";
    $get_one_result = $conn->query($get_one_sql);
    if ($get_one_result->num_rows == 1)
    {
        $get_one_row = $get_one_result->fetch_assoc();
        $car_name = $get_one_row['car_name'];
        $Manufacturer = $get_one_row['Manufacturer'];
        $Years = $get_one_row['Years'];
        $Type_of_car = $get_one_row['Type_of_car'];
        $Made = $get_one_row['Made'];
        $Base_engine_type = $get_one_row['Base_engine_type'];
        $Engine_size = $get_one_row['Engine_size'];
        $Drive_type = $get_one_row['Drive_type'];
        $Total_seating = $get_one_row['Total_seating'];
        $Estimated_Price = $get_one_row['Estimated_Price'];
        $Cylinders = $get_one_row['Cylinders'];
        $Descriptions = $get_one_row['Descriptions'];
        $images = $get_one_row['images'];

    }
    else
    {
        // $message = "<p>There was a problem retrieving the inforamtion</p>";
        header("Location:".THIS_PAGE."?m=notyourad");
    }
}

$count_sql ="SELECT count(*) FROM car
INNER JOIN user2 ON car.user_id = user2.user_id 
WHERE car.deleted_yn = 'N' AND user2.deleted_yn = 'N'";
$count_result = mysqli_query($conn, $count_sql);
$count_row = mysqli_fetch_row($count_result);
$count_of_records = $count_row[0];
?>

<?php 

include "inc/header.php";



?>
<h1>Welcome to the car category</h1>
<p>On this category this will show all kind of different cars that has been used in the on the road.
    in the navigation you can search a car for what you are looking for and can be filtered.
</p>

<div class="list">
    <?php 
    $view == 0;
    $list_sql = "SELECT carid, car_name, Manufacturer, Years, Type_of_car, Made, Base_engine_type, Engine_size, Drive_type, Total_seating, Estimated_Price, Cylinders, Descriptions, images, car.user_id 
    From car INNER JOIN user2 ON car.user_id = user2.user_id
    WHERE car.deleted_yn = 'N' AND user2.deleted_yn = 'N' $viewdetails $search_part";
    
    $list_result = $conn->query($list_sql);
    // echo $list_sql;
    
    ?>
        <?php if ($list_result->num_rows > 0): ?>
    <?php while ($list_row = $list_result->fetch_assoc()): ?>
    
        <?php if ($viewcar == false):?>  
        <div class="cars">
        <?php else: ?>   
            <div class="viewcars">
            <?php endif ?>   
        <?php if ($viewcar == false):?>   
        <table class="noview"> 
        <?php else: ?>
        <table class="viewcar">
        <?php endif ?>    
            <thead>
                <tr>
                    <?php echo '<img src="img_files/'.$list_row['images'].'">';?>
                    <th>Car Name:</th>
                    <th>Manufacturer:</th>
                    <th>Year:</th>
                    <?php if ($viewcar == false):?>
                </tr>
                <?php else: ?>
                    <th>Type of car:</th>
                    <th>Assebled:</th>
                    <th>Base Engine Type:</th>
                    <th>Estimated_Price:</th>
                    <th>Drive Type:</th>
                    <th>Engine Size:</th>
                    <th>Total Seats:</th>
                    <th>Cylinders:</th>
                    <th>Listed by:</th>
                    <th>Description:</th>
                    <?php endif ?>
                </tr>
            </thead>
            <tbody>
             
            <td><?php echo $list_row['car_name']; ?></td>
                <td><?php echo $list_row['Manufacturer']; ?></td>
                <td><?php echo $list_row['Years']; ?></td>
                <?php if ($viewcar == false):?>
                </tr>
                <?php else: ?>
                <td><?php echo $list_row['Type_of_car']; ?></td>
                <td><?php echo $list_row['Made']; ?></td>
                <td><?php echo $list_row['Base_engine_type']; ?></td>
                <td><?php echo $list_row['Estimated_Price']; ?></td>
                <td><?php echo $list_row['Drive_type']; ?></td>
                <td><?php echo $list_row['Engine_size']; ?></td>
                <td><?php echo $list_row['Total_seating']; ?></td>
                <td><?php echo $list_row['Cylinders']; ?></td>
                <td><?php echo $list_row['user_id']; ?></td>
                <td><?php echo $list_row['Descriptions']; ?></td>
                <?php endif ?>
                </td>
            </tbody>
        </table>
        <?php $carid = $list_row['carid']?>
        <?php if ($viewcar == true):?>
            <?php else: ?>
        <a class="viewdetails" href="index.php?view=<?php echo $carid; ?>" class="view-details">View details</a>
                        <?php endif ?>
        <?php if(isset($_SESSION['this-is-the-final-project-dmit-2025'])): ?>
            
        <?php if($_SESSION['user_id'] == $list_row['user_id']): ?>
      
        <a class="admin" href="<?php echo THIS_PAGE; ?>?carid=<?php echo $carid ?>">Edit</a>
        <a class="admin" href="deleted.php?carid=<?php echo $carid; ?>">Delete</a>
        </div>
        <?php endif ?>
        <?php else: ?>
            </div>
        <?php endif ?>




<?php endwhile ?>
<?php else: ?>
    <p>Sorry there are no car to display.</p> 
<?php endif ?>
</div>
<?php 
if (!isset($_SESSION['this-is-the-final-project-dmit-2025']))
{
    include "login-form.php";
}
else
{
    include 'add-form.php';
}
?>
<?php 
include "inc/footer.php";

?>
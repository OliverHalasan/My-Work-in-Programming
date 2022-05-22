<?php 
if (isset($_GET['search'])) {
    $search = $_GET['search'];
    $search_part = "AND (car.car_name LIKE '%$search%' OR car.Manufacturer LIKE '%$search%' OR
                        car.Made LIKE '%$search%' OR car.Years LIKE '%$search%'
                        OR car.Type_of_car LIKE '%$search%' OR car.Base_engine_type LIKE '%$search%' OR
                        car.Engine_size LIKE '%$search%' OR car.Drive_type LIKE '%$search%' OR 
                        car.Total_seating LIKE '%$search%' OR car.Estimated_Price LIKE '%$search%' OR
                        car.Cylinders LIKE '%$search%' OR car.Descriptions LIKE '%$search%')";
}
else
{
    $search = "";
    $search_part = "";
}

?>
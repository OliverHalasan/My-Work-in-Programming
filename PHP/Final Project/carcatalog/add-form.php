<!-- add from section -->
<div class="input">
<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST" enctype="multipart/form-data">
<?php 
    // Validation Message
    if (isset($validation)): ?>
        <div class="validation">
            <?php echo $validation; ?> 
        </div>
        <?php endif ?>

<!-- input data section -->

<!-- car name -->
<div>
<label for="car_name">Car Name</label>
<input type="text" name="car_name" id="car_name" value="<?php echo $car_name?>">
</div>
<!-- Brand -->
<div>
<label for="Manufacturer">Manufacturer</label>
<input type="text" name="Manufacturer" id="Manufacturer" value="<?php echo $Manufacturer?>">
</div>
<!-- Year -->
<div>
<label for="Years">Year</label>
<input type="number" name="Years" id="Years" value="<?php echo $Years?>">
</div>
<!-- Type of car -->
<div>
<label for="Type_of_car">Car Type</label>
<input type="text" name="Type_of_car" id="Type_of_car" value="<?php echo $Type_of_car?>">
</div>
<!-- Made -->
<div>
<label for="Made">Assembled</label>
<input type="text" name="Made" id="Made" value="<?php echo $Made?>">
</div>
<!-- what kind of gas -->
<div>
<label for="Base_engine_type">Base engine type</label>
<input type="text" name="Base_engine_type" id="Base_engine_type" value="<?php echo $Base_engine_type?>">
</div>
<!-- Engine size -->
<div>
<label for="Engine_size">Engine Size</label>
<input type="text" name="Engine_size" id="Engine_size" value="<?php echo $Engine_size?>">
</div>
<!-- Drive_type -->
<div>
<label for="Drive_type">Drive type</label>
<input type="text" name="Drive_type" id="Drive_type" value="<?php echo $Drive_type?>">
</div>
<!-- Total_seating -->
<div>
<label for="Total_seating">Total seats</label>
<input type="number" name="Total_seating" id="Total_seating" value="<?php echo $Total_seating?>">
</div>
<!-- Estimated_Price -->
<div>
<label for="Estimated_Price">Estimated Price</label>
<input type="text" name="Estimated_Price" id="Estimated_Price" value="<?php echo $Estimated_Price?>">
</div>
<!-- Cylinders -->
<div>
<label for="Cylinders">Cylinders</label>
<input type="text" name="Cylinders" id="Cylinders" value="<?php echo $Cylinders?>">
</div>
<!-- Description -->
<div>
<label for="Descriptions">Description</label>
<textarea name="Descriptions" id="Descriptions"><?php echo $Description ?></textarea>
</div>
<!-- image -->
<div>
<label for="image">Car Name</label>
<input type="file" name="images" id="images">
</div>
<div>
<input type="submit" name="NewCar" value="Add a Car">
</div>
</form>
</div>
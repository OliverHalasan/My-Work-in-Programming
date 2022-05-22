<div class="newdata">
<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST">
<?php 
    if (isset($validation)): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="job_title">Job Title</label>
<input type="text" name="job_title" id="job_title" value="<?php echo $job_title ?>">

<label for="job_ad">Ad</label>
<textarea name="job_ad" id="job_ad"><?php echo $job_ad ?></textarea>

<input type="submit" name="job-ad-submit" value="Post my ad!">
</form>
<div>
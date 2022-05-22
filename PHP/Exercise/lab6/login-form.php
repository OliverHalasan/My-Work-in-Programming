<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST">
<div class="login-form">
<?php 
    if ($validation): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="email">email or User Name</label>
<input type="text" name="email" id="email" value="<?php echo $email ?>">

<label for="password">Passoword</label>
<input type="text" name="password" id="password" value="<?php echo $password ?>">

<input type="submit" name="login-submit" value="Login!">
</div>
</form>
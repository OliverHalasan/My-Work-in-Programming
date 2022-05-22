<form action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']) ?>" method="POST">
<div class="login-form">
<?php 
    if ($validation): ?>
    <div class="validation">
        <?php echo $validation; ?> 
    </div>
    <?php endif ?>

<label for="email">email or User Name</label>
<input class="login" type="text" name="email" id="email" value="<?php echo $email ?>">

<label for="password">Passoword</label>
<input class="login" type="text" name="password" id="password" value="<?php echo $password ?>">

<input class="loginsub" type="submit" name="login-now" value="Login!">
</div>
</form>
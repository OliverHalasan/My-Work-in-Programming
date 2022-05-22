<form action="<?php echo htmlspecialchars($_SERVER['REQUEST_URI']); ?>">
<div class="search-form">
    <label for="search">Search</label>
    <input type="text" name="search" id="search" value="<?php echo $search; ?>">

    <input type="submit" name="search-submit">
</div>
</form>
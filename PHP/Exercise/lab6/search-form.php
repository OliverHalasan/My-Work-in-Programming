
<form action="<?php echo htmlspecialchars($_SERVER['REQUEST_URI']); ?>">
<div class="search-form">
    <label for="search">Search</label>
    <input type="text" name="search" id="search" value="<?php echo $search; ?>">

    <label for="order-by">Order by</label>
    <select name="order-by" id="order-by">
        <option value="title">Title</option>
        <option value="ad_id">Date Poster</option>
        <option vale="user_names">User</option>
    </select>

    <fieldset>
        <input type="radio" name="order" id="ASC" value="ASC" <?php if ($order == "ASC") { echo "checked";} ?>>
        <label for="ASC">ASC</label>

        <input type="radio" name="order" id="DESC" value="DESC" <?php if ($order == "DESC") { echo "Checked"; } ?>>
        <label for="DESC">DESC</label>
    </fieldset>

    <label for="limit">Limit</label>
    <select name="limit" id="limit">
        <option value="3">3</option>
        <option value="6">6</option>
        <option value="10">10</option>
    </select>
    <input type="submit" name="search-submit">
    </div>
</form>
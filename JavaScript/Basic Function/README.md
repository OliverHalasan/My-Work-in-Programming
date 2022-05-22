# In Class Assessment 2 - Working with Functions [2.5%]

> **Oliver Halasan**

You have been supplied HTML, CSS, and JavaScript files for this assessment. This assessment tests your ability to:

- Include an external JavaScript file in an HTML document
- Create a simple JavaScript function

## Instructions

Modify the supplied HTML file to add a script tag immediately before the closing tag for the body. The script tag must link to the supplied JavaScript file.

> *Do **NOT** make any other modifications to the HTML file.*

In the JavaScript file, create a function named `italics` that accepts a single parameter value and returns that value enclosed within the italics (`<i></i>`) tag. Ensure that the function cannot be modified in the browser.

### Testing

You can test the behaviour of your function in the browser's console window. The `updateInnerHTML` function is provided to aid you in testing your function. Use it along with your `italics` function to change the `'span.note'` element's `innerHTML` to have its current value wrapped with the `<i>` tags. The HTML for that element should then look as follows:

```html
<span class="note"><i>Note:</i></span>
```

## Submission

Ensure that you have saved the changes to your repository. Then commit and push those changes to GitHub.

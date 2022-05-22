# dmit1530-lab-02

## Lab 02: Single-Level Drop-Down Menu

**Due**: Sunday @ 23:55 MST

**Weight**: 5% of your final grade

---

## Instructions

Clone a copy of this repository to your device so that you can develop it locally. When you finish, make sure to push your latest commit to GitHub Classroom. 

For this Lab, you will create a website for a fictitious Geltao shop in southern Queensland, Australia. It will be  a Code-A-Long where you are expected to put in the final touches.

---

## The Build Methodology

1. Begin by optimising your images (using Squoosh, Photoshop, or the image editing program of your choice). Your goal is to get your background images under 250KB, as per current Google recommendations. 

2. Write all of the necessary HTML. This will include a ``<header>`` with a ``<nav>`` and a ``<section>`` for a hero banner. Inside of your ``<nav>``, you will have an unordered list with a class of ``.menu`` and two nested unordered lists with a class of ``.submenu``. Altogether, you menu will have the following links and nested links: 

	> Current Flavours

	> About

		>> Our Story

		>> Farms

		>> Collaborators 

		>> Sustainability 

		>> FAQs
	
	> Shops

		>> Coolangatta

		>> Fortitude Valley

		>> Mooloolaba Beach

		>> South Brisbane

	> Contact

3. In your ``<nav>``, include the provided ``<svg>`` beside the links with nested menus. 

4. In your ``<section>``, make sure that there are two non-semantic child elements. One should be empty, while the other should container your typographic elements. We will use these as flex items for the desktop view.

5. Validate and outline your HTML. You should not have any validation errors or _Untitled Sections_. You **must** have a flawless foundation before you can begin writing your CSS.

6. Begin by writing universal styles (i.e. things that will remain the same regardless of the size of the viewport).

7. Next, style everything for the mobile view. Your ``<nav>`` should be vertical and fill the full width of the screen. For this view, your ``<svg>`` element should be hidden, as you will not need anything to indicate that there are sub-menus. Underneath, your hero banner should have the darker, smaller background, with all of its contents centred. 

8. Begin styling the desktop view. Using a media query, define your flex containers. 

9. Make your ``<svg>`` element visible again.

10. Position and hide your nested links (i.e. the drop-down menu). 

11. Make them appear again whenever the user hovers over the parent ``<li>``. Add a transition to make everything a little smoother.

12. Add accessibility with the :focus and :focus-within state on each ``<li>``. This will allow users to tab through all of your links with their keyboard or a swipe rather than having to click it with a mouse or a tap. 

13. Finally, write a media query for the largest view. In it, prevent the flex items within the hero banner from growing any further.
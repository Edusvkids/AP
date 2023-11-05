//Select all of the image continers.

const slideAreas = document.querySelectorAll('div.slides');

//loop over each image container and select all images in each container

slideAreas.forEach(slideArea => {
	const images = slideArea.querySelectorAll('.sneaker_img');

// keep track of slides 

let currentSlide = 0;
let z = 1;

// when slide area is clicked change based on z-index

slideArea.addEventListener('click', function() {
		currentSlide = currentSlide + 1;
		if(currentSlide > images.length - 1) {
			 	currentSlide = 0;
			 }
		z = z + 1;
		// remove the animation from the style for EVERY image
		images.forEach(image => {
			image.style.animation = '';
		})
		//pick the right image
		images[currentSlide].style.zIndex = z;
		images[currentSlide].style.animation = 'fade 0.5s'
});

// When mouse over slide area, put all images in random place

slideArea.addEventListener('mouseover', function() {
	images.forEach(image => {
		const x = 10 * (Math.floor(Math.random() * 4)) - 15;
		const y = 10 * (Math.floor(Math.random() * 4)) - 15;
		
		image.style.transform = `translate(${x}px, ${y}px)`;
	})
});

// When mouse away, put images back

slideArea.addEventListener('mouseout', function() {
	images.forEach(image => {
		image.style.transform = '';
	})
});
	
});
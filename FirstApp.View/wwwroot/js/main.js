window.calculateTransformAndApply = (scroller, currentIndex, direction) => {
    const translateX = -currentIndex * 100 + (direction / window.innerWidth * 100); // Calculate translation
    scroller.style.transform = `translateX(${translateX}%)`; // Apply the transformation
};
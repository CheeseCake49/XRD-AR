# Aligning the World and Finding Our Direction  

Today’s focus was on refining what we had already built — getting the virtual world properly aligned with the real one, and finally implementing our long-awaited direction arrow (which, for now, is still the floating rifle). It was a day of small but meaningful victories.  

---

## Revisiting the Setup  

We began the day by testing again, trying to get a clear overview of where we had left off. The first challenge was still related to **alignment and rotation**. When we scanned the QR code attached to the wall, the entire modelled world appeared rotated — the floor ended up on the wall again. But when we placed the same QR code on the **floor**, everything appeared exactly as intended.  

After some investigation, we realized the orientation problem came from how the world origin was being defined in Unity. We spent a while manually rotating and adjusting the world, testing different placements to ensure consistency. It took some patience, but eventually we achieved the correct alignment without breaking other parts of the project.  

---

## Implementing the Direction Rifle  

With the world orientation under control, the next major step was implementing our **direction arrow** — still represented by the iconic rifle model. This time, we wanted to remove all other elements from the modelled world except the rifle itself. That meant carefully locating and deleting dozens of game objects inside the Unity hierarchy, which was far trickier than expected.  

To make things worse, **Unity wasn’t cooperating**. The software kept freezing, crashing, or failing to render updates properly. Every adjustment took longer than it should have, and we found ourselves stuck in an endless loop of reloading and troubleshooting. Still, persistence paid off — we eventually managed to isolate the rifle, add a **floating animation** to it, and prepare for another real-world test.  

---

## Testing the Path  

We placed the QR code back on the wall and scanned it again. This time, the only visible object was our **direction rifle** — and it worked! The rifle appeared where it was supposed to, floating and animated. But there was a new issue: it was **pointing in the wrong direction**, rotated about 90 degrees off from where it should have been.  

Another problem was that the rifle seemed to **sink “through” the floor** when viewed from certain angles, disappearing from the camera frame instead of staying fixed in place. Despite these quirks, we decided to continue testing by walking through the environment along the intended route — following the rifle’s path toward the canteen.  

And there it was: when we reached the canteen, we found our **floating and rotating rifle waypoint** exactly where we had placed it! Seeing it appear in the real-world space, correctly aligned with the virtual model, felt like a major breakthrough.  

---

## Final Adjustments and Success  

The last task was to fine-tune the orientation and positioning. We rotated the rifle by 90 degrees and slightly adjusted its height to keep it consistently visible within the phone frame. It took **two more attempts** to perfect everything, but the final result was spot on.  

To wrap up the day, we made a **screen recording** of the working demo directly from the phone — a small but satisfying moment after hours of troubleshooting, rotations, and refinements.  

---

## Reflection  

Today was all about perseverance. From fixing rotation mismatches to refining Unity’s object hierarchy and fighting off software crashes, every step brought us closer to a more stable and interactive experience. The floating rifle now behaves exactly as we imagined — an amusing, stylized waypoint.

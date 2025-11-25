# Final Touches Before the EXPO  

Today marked our **last development session** before the big EXPO, and the goal was simple: refine what we already had, add small quality-of-life features, and prepare a stable build for the Meta Quest headset. With the deadline so close, every improvement counted.  

---

## Making the Ball Visible  

One of the biggest challenges we wanted to solve was the **visibility of the ball after a serve**. Inside the headset, due to resolution limits and the natural speed of the serve, the ball can be extremely difficult to track — especially once it hits the ground.  

We agreed that the player needed **visual feedback** to evaluate their serve, so we brainstormed a few ideas. One suggestion was to light up the opponent’s service box when a serve was valid, but ultimately we chose a more precise and intuitive solution:  
**hitmarkers at the ball’s landing point.**

The logic was simple:  
- **Green dot** = the ball lands inside the correct service box.  
- **Red dot** = the serve is out.  

---

## First Implementation Chaos  

As always, the first version was… interesting.  

For starters, the game kept placing a hitmarker the *moment* the racket struck the ball, counting it as an impact on the ground. That was obviously not ideal.  

Then came the next issue:  
The hitmarkers **never disappeared**. After a few serves, the court looked like a rainbow polka-dot crime scene.  

We added timers so that markers would fade out after a short duration, which solved that part. But the second challenge — ensuring the racket didn’t trigger hitmarkers — turned out to be much harder than expected.  

Even when we tried to detect only the *second* collision (the real bounce), the racket still generated multiple phantom hits during the serve, and we still don’t know why.  

On top of that, we discovered that the ball was sometimes marked **green even when landing behind the service line**, which is obviously out. Thankfully, we managed a fix: the ball now correctly displays **green only when landing within the defined service area**, and **red everywhere else**.  

We didn’t manage to fully eliminate the racket-triggered hitmarkers, but for the sake of the prototype — and the time we had left — we decided it was acceptable.  

---

## The Final Build  

With the main feature implemented, there was only one thing left to do:  
**build the project for the headset and record a demo.**  

Seeing everything run in the actual device felt both exciting and surreal. After weeks of physics tweaks, object rebuilding, headset issues, and wild troubleshooting, it was satisfying to watch a playable — and demonstrable — version come to life.  

A fun and hectic finale to the prototype sprint.  
Now, we’re ready for the EXPO.  

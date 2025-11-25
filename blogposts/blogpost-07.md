# Wrestling With Physics and Perception  

Last week’s session was dedicated almost entirely to improving the **ball physics**, with the goal of making the Padel Serve Simulator feel as realistic as possible. What we expected to be a straightforward tuning process quickly evolved into a surprisingly complex and slightly chaotic exploration of Unity physics.  

---

## Chasing the Perfect Ball Behaviour  

We began by addressing the most obvious issue:  
The ball travelled **way too fast**, even from the softest touch.  

Our initial assumption was that the ball itself simply didn’t have enough mass. We experimented with changes in **linear damping**, adjusting how quickly the ball loses speed after being hit. When that didn’t get us far, we tried the more brute-force approach — gradually increasing the ball’s mass.  

A little bit at first.  
Then a bit more.  
Then ten times more.  
Eventually… more than a **million**.  

Despite this absurd number, nothing changed. The ball behaved exactly the same, and because the physics were already unstable, it was nearly impossible to replicate the same swing perfectly each time to test the results.  

That’s when it finally hit us:  
Maybe the ball wasn’t the problem at all.  

---

## It's Not the Ball — It’s the World  

We took a closer look at the environment and realized something we had completely overlooked:  
The **physics materials** on everything — racket, walls, floor — were all set in ways that gave them **super bounce** qualities.  

No wonder the ball felt like it had been launched from a cannon.  

Once we replaced the physics materials with more appropriate ones and reduced the bounciness across the environment, the behaviour immediately became more stable. The ball still wasn’t perfect, but at least it was now behaving like a ball in a court, not a rubber bullet in a pinball machine.  

---

## A Strange Sense of Scale  

With the physics behaving better, we moved on to the next issue:  
Something about the court **felt off**.  

The net looked too high.  
The walls and fences felt correct.  
But playing didn’t *feel* right.  

This was confusing because all measurements were taken directly from the official padel court specifications. To test our theory, we experimented with adjusting the **camera start height**, but that only made things more confusing — the walls suddenly looked too small, the court felt tiny, and the whole space lost its sense of proportion.  

After enough back-and-forth testing, we concluded the culprit wasn’t our model at all.  

It was the **headset’s perception of scale**.  
The Meta Quest sometimes distorts the feeling of height or distance depending on the player’s physical height and how the playspace is calibrated.  

In other words:  
Everything was technically correct — it just *felt* wrong.  

---

## Wrapping Up  

We ended the session with a deeper understanding of how sensitive VR physics and perception can be. Fixing the stability of the ball was a big step forward, and even though the sense of scale mystery wasn’t fully solved, we at least identified the likely cause.  

Next time, we’ll focus on fine-tuning the physics further and finding a consistent way to make the court feel “right” inside the headset.  

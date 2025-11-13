# The Birth of the Padel Serve Simulator  

Today’s session took a more exploratory and creative turn as we continued experimenting with VR ideas — and for some of us, it even included our *very first* time trying a VR headset.

---

## Early Brainstorming  

We started the day by sharing and testing ideas, and one unexpected moment of inspiration came when one group member tried hand tracking in VR for the first time. The aiming gesture felt strangely like something out of a superhero movie, which sparked a short-lived but enthusiastic suggestion for a **Spiderman-style simulator**.  

But then a completely unrelated conversation changed everything. Someone mentioned **SimGolf**, and how useful it is for practicing indoors. This led one of our members to vent about his ongoing frustration with improving his **padel serve** — and suddenly, the energy in the room shifted.  

What if we made a **Padel Serve Simulator**?  
A VR environment where you could practice the technique, experiment with spin, and work on power without needing a full court. The idea felt instantly meaningful and technically exciting, and just like that, our direction was set.  

---

## Why a Padel Simulator?  

We liked the idea because it gave us the opportunity to dive deeper into **unique physics challenges**. Simulating how a ball behaves after being hit — including trajectory, spin, and speed — is far more complex than it sounds.  

One of our members had just come off his first VR experience: a 15-minute trial of a table tennis game. Fun as it was, it highlighted a key issue: the ball physics felt *off*. Speed and impact didn’t feel connected to the force of the swing.  

This confirmed that physics would be a major focus of our project. If we could get this right, the simulator could feel genuinely authentic.  

---

## Building the Court  

With the concept in place, we began searching for a **padel court model** in the Unity Asset Store. Unsurprisingly, given the sport’s growing popularity, only **one** asset existed — priced at 27 euros.  

After a quick team meeting (and the realization that our student budgets did not stretch that far), we decided to **build the court ourselves**.  

Surprisingly, creating a simple court layout turned out to be a fairly quick and manageable task. It wasn’t fancy yet, but it gave us exactly what we needed to move forward.  

---

## Adding the Ball — and the Pink Problem  

Next up was the padel/tennis ball. We downloaded a few ball models, but every time we imported them into Unity, they showed up as **bright neon pink**.  

At first we thought it was a shader issue. Then a rendering problem. Then maybe a texture path problem.  
After a long stretch of troubleshooting (and rising frustration levels), we asked our teacher for help.  

The answer was simple:  
The models we downloaded were **outdated**, and the rendering pipeline they relied on was no longer supported.  

With a quick fix suggested by the teacher, we restored the proper **lime-green** color. Suddenly, the ball looked like a ball again.  

---

## Planning the Racket  

Before we knew it, the session was nearly over. We ended the day by planning the next big step: creating the **padel racket**.  

With the asset store empty of padel-specific models and no budget for paid options, we narrowed the solution down to two realistic choices:  

1. **Scan a real-life racket** and clean it up in Blender, or  
2. **Build a simple stylized racket** directly in Unity using cylinder primitives.  

Given the time we had left — and the fact that the built-in geometry looked good enough for prototyping — we chose the second option. The actual implementation, however, would have to wait for our next session.  

---

## Reflection  

Although today was heavily concept-driven, it was also a pivotal moment for our project. The idea for the Padel Serve Simulator wasn’t just interesting; it sparked excitement because it combined physics, interaction, and VR in a meaningful, practical way.  

Next time, we’ll focus on constructing the racket and moving toward our first playable prototype.  

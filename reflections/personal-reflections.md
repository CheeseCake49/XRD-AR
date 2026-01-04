### List Of Contributions

Throughout this course everything has been created, tested, and worked on together. As for the DevBlogs, we have discussed what was to be included in a forum and then taken turns on who wrote the blogs.

*Please note that pretty much all of the work was always done when all members were present.*

If we were to point out who operated the computer in each phase, while the other members participated on the sideline, then the list would look like the following:

**Emil:**

AR Project (1): 
1. Mapped campus (Lidar scanner)
2. Added navigation pointer and canteen pointer (weapons)
3. Deployed to iPhone
4. Recorded the demonstration video

VR Padel Sim Project (2):
1. Found models
2. Fixed racket physics
3. Created ball spawning script


**Johan:**

AR Project (1): 
1. Stitched the world together
2. Fixed incorrect axis
3. Created tracking script

VR Padel Sim Project (2):
1. Fixed ball physics
2. Added ball zone hitmarkers script

**Luu:**

AR Project (1): 
1. Found models (the weapon used as pointer)
2. Created QR code for world calibration
3. Created canteen pointer hovering script

VR Padel Sim Project (2):
1. Mapped the court and world
2. Primary tester (given real world padel experience)

---

# **<ins>Personal Reflections on XRD<ins>**

# Emil:

Looking back on this semester, I'm surprised by how much I've learned. Coming into this course, I had zero experience with XR and I have barely even tried a VR headset before. Now, I'm sitting here considering getting my own VR headset, which I think says a lot about how this course went. 

#### The AR Navigation Project

The first project instantly showed me how challenging XR development can be. Building an AR navigation app for VIA campus seemed straightforward on paper, but the reality was much messier - though in a good way. The biggest early challenge was simply figuring out how to scan our campus effectively. My iPhone's Lidar scanner kept choking on the file sizes when we tried to capture everything in one go, which forced us to break the environment into smaller chunks and stitch them together in Unity later. It was tedious, but it taught me a valuable lesson about working within hardware limitations rather than against them. 

Unity itself was completely new territory for me. I have used it way back when I was a kid but I had forgotten most things. I remember the first time we spawned our scanned world into the scene and it appeared on completely the wrong axis. The floor was on the wall, everything was rotated 90 degrees off. Figuring out how to align the virtual model with the real-world campus took problem-solving, and honestly, it felt good when we finally got it right. Learning about techniques like occlusion was particularly satisfying. The idea that out waypoint marker (weapon) would only appear when it would actually be visible in real life, that showcased some of the cool things you can do with AR.

#### The VR Padel Simulator

The second project felt like a completely different task. Creating a VR padel serve simulator gave me my first real taste of VR development, and it was both more fun and technically challenging than I expected. Early on, we struggled with getting the court dimensions to feel right. Everything was technically accurate according to offical padel court measurements, but something felt off in the headset. The net seemed too high, the court felt too large. We eventually accepted it, and figured that this was likely a perceptual issue with how the Quest tracks scale rather than an actual modeling problem, which was frustrating. It's one of those quirks you just don't think about until you're wearing the headset. 

The physics side of things were probably the most challenging. We spent hours tweaking ball behaviour, starting with the assumption that the ball's mass was wrong. At one point, we'd increase its mass to over a million times the original values, and nothing changed. Turns out the real culprit was the physics materials on the court surfaces. Everything had super bouncy properties that made the ball behave like it was fired from a cannon. Once we figured that out, things improved a lot, but it took way longer than it should have.

Getting the ball to interact properly with the racket was another headache. It kept glitching straight through, which completely ruined the feel of the simulation. We eventually adjusted how Unity calculated collisions, and while it improved, it still wasn't perfect. But that imperfection taught me something important being sometimes "good enough" is actually good enough, especially when you're prototyping under time constraints.

#### What I Took Away

Beyond the technical skills - and I did learn a lot about Unity, physics systems, materials, scripting, and how everything interconnects - this course completely shifted my understanding of game development. I had no idea how time-consuming it could be. We poured hours into both projects, and while the final results weren't particularly flashy or polished, they worked - and that felt like an accomplishment.

It was also really nice to have a facilitator to turn to when things got difficult. Having someone to turn to when we hit a wall - like when the ball physics made no sense or when the balls kept glitching through the racket - saved us time. It's one thing to search the internet for solutions, but having an expert say "yeah, that's a known issue", is really awesome when you're learning. 

#### Looking Forward

If there's one thing this course has done, it's opened my eyes to jsut how complex and creative XR development can be. I came in with no expectations and I'm leaving with a genuine interest in continuing to explore this space. If I were to buy my own VR headset in the future, then I believe that I'd take these experiences I have gathered and use that to try and build my own fun projects. This course was really fun, messy, challenging and interesting.

---
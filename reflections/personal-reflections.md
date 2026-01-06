### Note On List Of Contributions

Throughout this course everything has been created, tested, and worked on together. As for the DevBlogs, we have discussed what was to be included in a forum and then taken turns on who wrote the blogs.

*Please note that pretty much all of the work was always done when all members were present at VIA Campus.*

---

# **<ins>Personal Reflections on XRD<ins>**

# Emil:

##### List Of Contributions

If I were to point out the elements I worked on while sitting at the computer, while the others sat next to me, then the list would look like the following:

AR Project (1): 
1. Mapped campus (Lidar scanner)
2. Added navigation pointer and canteen pointer (weapons)
3. Deployed to iPhone
4. Recorded the demonstration video

VR Padel Sim Project (2):
1. Found models
2. Fixed racket physics
3. Created ball spawning script

### Reflections

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

# Johan

##### List Of Contributions

Throughout the course, almost all development work was carried out collaboratively, with the entire group present. This was largely due to practical constraints: we relied on school equipment for both AR and VR testing, and we also made a conscious decision early on to work together to avoid potential issues with Unity project files and version control. Since two group members had limited prior experience with Unity, we wanted to minimize the risk of merge conflicts or corrupted binary files in Git by keeping development sessions shared and supervised.

As a result, there were very few tasks completed entirely independently. Instead, contributions were made through hands-on implementation while the rest of the group participated in discussion, testing, and problem-solving. That said, if I were to identify the specific elements I was primarily responsible for while working at the computer, my main contributions can be summarized as follows:

### **AR Navigation Project**
- Stitched together the scanned world environment  
- Corrected incorrect axis alignment issues in the imported AR scene  
- Created and implemented a tracking script for navigation functionality  

### **VR Padel Simulator**
- Fixed issues related to ball physics behavior  
- Implemented a ball zone hitmarker script to register successful hits  

---

### Reflections

Looking back on the semester, one of the strongest impressions I am left with is how unpredictable XR development can be, especially when relying on unfamiliar tools and hardware. While both projects were technically interesting, they also highlighted how external constraints—such as software limitations, hardware reliability, and perception-related issues—can significantly affect both workflow and motivation.

#### The AR Navigation Project

The AR navigation project was technically challenging right from the start, primarily due to issues related to the LiDAR scanning software we used. We were initially told that we could rely on a free scanning app, but shortly after beginning the project, we discovered that the app had been updated and was now limited to a trial version. This introduced several unexpected restrictions, including limits on the number of scans we could perform and the file formats we were allowed to export. These limitations were not immediately obvious and only became clear after we had already invested time into scanning.

A major issue arose from the scale of the area we chose to scan. Because our navigation concept relied on a large, continuous 3D environment, we spent a significant amount of time scanning a massive area of the campus. However, once the scan was complete, the app repeatedly crashed or failed during the processing stage, making it impossible to export the scan for use in Unity. Since the scan had to be fully processed before it could be edited or cropped, there was no way to salvage parts of the data we had already captured.

As a result, we ended up spending nearly two full days scanning and reprocessing the same area multiple times, only to realize that we would need to switch to a different scanning app for the remaining work because we had exhausted the scan limits in the first one. This was a significant time loss and a fairly demotivating way to begin the project, especially since the issue was not related to our implementation or understanding, but rather to tooling constraints outside our control. That said, the experience taught me an important lesson about validating tools and their limitations early in a project, particularly when those tools are critical to the entire pipeline.

Once we finally had usable scan data, the technical challenges shifted toward integrating it properly into Unity. Issues such as incorrect axis orientation and aligning the virtual environment with the real world required careful adjustment and testing. Creating and refining the tracking logic also made it clear how sensitive AR experiences are to small inconsistencies—minor alignment errors quickly became noticeable and affected the overall usability of the navigation system.

#### The VR Padel Simulator

Compared to the AR project, the VR padel simulator was less affected by external software limitations, but it introduced a different set of technical challenges, particularly related to hardware and perception. One of the more frustrating moments occurred when we spent roughly half a day trying to get the assigned VR headset to function properly. Despite knowing that the project worked with a different headset, we were unable to get a stable connection to the PC, and when it finally connected, the application would not build or run correctly. The headset was also lagging heavily, even in menus, making it nearly impossible to test anything. Since the workstation and headset were pre-assigned, this was largely out of our control and resulted in a significant loss of productive development time.

From a development standpoint, one of the most interesting challenges was achieving a believable sense of scale. Because the simulator was based on a real-world sport, accuracy mattered a lot. We built the court according to official measurements, and technically everything was correct. However, once inside the headset, some elements felt wrong. The walls and distances across the court felt natural, but the net, despite being the correct height on paper, felt unrealistically tall. This mismatch between numerical correctness and perceived scale was difficult to resolve and highlighted how human perception in VR does not always align with real-world measurements. In the end, this forced us to accept that realism in VR is not purely about accuracy, but also about how the experience feels to the user.

#### What I Took Away

Across both projects, I learned that XR development is as much about managing constraints as it is about implementing features. Technical issues often stemmed not from incorrect code, but from tools, hardware, or perceptual factors that were difficult to predict in advance. Working collaboratively throughout the process helped mitigate some of this frustration, as problems were discussed and solved collectively rather than in isolation.

On a personal level, these projects strengthened my ability to troubleshoot complex technical issues, adapt to unexpected setbacks, and make pragmatic decisions when ideal solutions were not feasible. Even when progress felt slow or inefficient, each challenge contributed to a better understanding of how AR and VR systems behave in practice. Overall, the semester provided a realistic and valuable insight into XR development, highlighting both its potential and its practical difficulties.

---

# Luu

##### List Of Contributions

### **AR Navigation Project**
- Contributed to early idea generation and concept development for the navigation experience  
- Participated in LiDAR scanning of the campus environment and refinement of scan segments  
- Assisted with evaluating scan quality, identifying alignment issues, and testing different scanning approaches  
- Took part in refining navigation flow and waypoint placement, including usability considerations  
- Contributed to testing and validating AR alignment and tracking behaviour in real-world conditions  

### **VR Padel Simulator**
- Participated in concept development and design discussions, particularly around realism and user experience  
- Acted as the primary tester, repeatedly testing the simulator in-headset and reporting issues related to physics, collisions, and scale perception  
- Helped identify and document ball behaviour issues, including excessive speed, bounce inconsistencies, and collision problems  
- Contributed feedback on court feel, scale, and usability, helping guide physics and visual adjustments  
- Supported iteration by testing new builds and verifying fixes before moving forward  

---

## **Personal Reflection**

I found this course both very interesting and genuinely challenging, and I am proud of what our group managed to create over the semester. Even though my role was less focused on hands-on implementation compared to some of my group members, being part of the full development process gave me valuable insight into how XR projects actually take shape in practice.

Between the two main areas we explored, AR was the field that excited me the most. I strongly believe that AR has enormous potential going forward, especially in smaller-scale, practical applications rather than large, highly polished consumer products. Our AR navigation project made this very clear to me. The idea of using AR to enhance real-world environments in subtle but useful ways — such as navigation or spatial guidance — felt both realistic and impactful. I could easily imagine myself working on similar AR features in the future, where the goal is not to create something flashy, but something genuinely helpful.

At the same time, this course made me realize just how difficult XR development can be. Many of the challenges we faced were not purely about writing code or building models, but about dealing with hardware limitations, software constraints, and unpredictable behaviour in both AR and VR environments. Watching how small changes in physics settings, tracking configurations, or headset calibration could dramatically affect the experience was eye-opening. It gave me a much greater appreciation for how fragile and interconnected XR systems are.

I also came to terms with the fact that I personally found the course difficult. There were moments where it was hard to fully keep up with the technical implementation, especially during more complex Unity or physics-related work. In that sense, having a supportive and capable group was essential. Being present during development sessions, participating in testing, discussing design decisions, and documenting the process through the dev blogs allowed me to stay engaged and contribute meaningfully, even when I wasn’t the one directly implementing features.

Overall, this course broadened my understanding of XR as a field. It showed me that building XR applications is rarely straightforward, but also that even rough prototypes can be incredibly rewarding when they work. Despite the challenges, the experience left me with a strong sense of accomplishment — not because everything was perfect, but because we managed to create functional AR and VR applications from scratch. That, to me, feels like a solid and motivating outcome.

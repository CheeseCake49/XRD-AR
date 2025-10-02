# Testing Reference Points and First App Build  

Today was a busy day filled with asset hunting, experimenting with reference points, and our first attempts at running the application on iOS. The day was very iterative, with a lot of problem solving, testing, and unexpected discoveries along the way.  

---

## Asset Hunting  

We started by **browsing and downloading assets** for the project. The original plan was to use a simple **arrow** as a waypoint marker in the app, but as we went through asset options we began thinking about ways to make the project a little more playful. At some point the idea came up that it would be fun, in a slightly tongue-in-cheek way, to replace the arrow with a **rifle model** instead. The idea was that instead of a typical directional pointer, users would encounter a floating rifle in the space. This was inspired by the kind of pick-up icons you might see in old GTA games, where you could walk into floating weapons to collect them. We imagined the canteen featuring such a floating rifle-point, which would be both functional and amusing.  

The idea might not be the most conventional, but it perfectly reflected the creative spirit of the project. It showed how we’re not just trying to build a purely technical pipeline - we’re also experimenting with user experience and interaction in fun and unexpected ways.  

---

## Creating a Reference Point  

Alongside the asset hunt, we also worked on anchoring our 3D scans to reality. For this, we created and printed a **QR code** to act as one of our main reference points. The idea was to use the code as a marker that could be recognized by the application, helping it to properly position the scanned environment in Unity. After generating the QR code, we used it on different surfaces and angles, and attempted to integrate it into our Unity project. While it was simple in theory, in practice it gave us plenty of things to troubleshoot.  

At first the QR marker didn’t seem to align properly with the model. We had to adjust positioning inside Unity and try multiple times to ensure the app recognized it consistently. Each attempt taught us a bit more about how Unity interprets reference points, and how finicky real-world testing can be compared to the neat setups in theory.  

---

## iOS vs. Android Testing  

Once we had assets and reference points in place, we wanted to test the application on actual devices. Here we hit one of the biggest obstacles of the day: **platform restrictions**. Apple’s ecosystem is famously strict, and testing an app on iPhone required us to build it through **Xcode**, which added several layers of complication. Kasper, our teacher, guided us through the options and explained that using an **Android device** is usually much simpler for testing AR projects. Android allows for faster iterations and avoids some of the heavy setup Apple requires.  

The problem for us, however, was that our entire team uses iPhones. While scanning had been very convenient on iPhone earlier, we now needed to figure out how to actually run the Unity app on one. After some trial and error, we managed to build the project through Xcode on Emil’s MacBook. Finally, we could run the application directly on an iPhone and attempt to scan the QR reference point in real-time. The result was both exciting and confusing: the app ran, but the **virtual world looked strange and distorted**, as if our environment had been shifted into some bizarre alternate reality. Eventually, we realized that this was because our reference point had been placed **very far away from the model inside Unity**, causing everything to appear offset in the app. It was one of those small but eye-opening mistakes that can only be caught by testing on real hardware.  

---

## Final Test on Site  

After a full day of trial and error, we decided to wrap things up with a test in the **real-world location**. We held the QR code onto the intended wall and ran the app again. This time, the model did load, but something was still off: the **floor of the model appeared rotated onto the wall**, which was both amusing and frustrating. We tried adjusting the QR code placement and changing angles, testing different orientations to see how the app would interpret the marker. Eventually, we discovered that placing the QR code **on the floor itself** finally gave us a correct orientation.  

This little breakthrough was encouraging - it proved that the pipeline was working, even if it still needed refinement. The app could load the scanned model and position it in space based on a real-world QR reference point. Even though our waypoint wasn’t active yet, and the rifle asset was still only a plan, the test gave us confidence that we were moving in the right direction.  

---

## Reflections  

Today was a reminder that technical progress often comes through a mix of experimentation, mistakes, and persistence. We had our share of strange results, but each one taught us something valuable about how Unity handles spatial alignment, how strict Apple’s testing pipeline can be, and how important it is to plan reference points carefully. It was also encouraging to see how a playful idea, like turning an arrow into a floating rifle, can make the whole process more enjoyable.  

While we still have a lot of work ahead - like implementing actual directional waypoints and ensuring the model loads with the correct orientation every time - we ended the day with real progress. The app ran, the model loaded, and the reference point worked, even if it meant seeing the world tilted sideways before we got it right. For a first iOS build and on-site test, that’s a big step forward.  

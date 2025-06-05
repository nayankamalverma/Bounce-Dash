# Bounce Dash
video - <a href="https://drive.google.com/file/d/18eCFhP7X3SBnzjfETmj6Mk7NVoflnkfn/view?usp=sharing">Click here</a>
<p>Bounce Dash is a hyper-casual 2D game where the player controls a bouncing ball that dodges obstacles and climbs platforms keep on the platforms as long as you can to score and collect coins.</p>
<p>Core Gameplay</p>
<ul>
<li>The player controls a bouncing ball that automatically bounces vertically.</li>
<li>Move the ball left or right using: Keyboard: A/D or ←/→ keys</li>
<li>The level scrolls vertically as the ball climbs.</li>
<li>Obstacles: spikes</li>
<li>Collectibles: Coins</li>
<li> Game Over occurs when hitting any obstacle.</li>
<li>The goal is to achieve the highest score possible.</li>
</ul>
<p>Technical Details</p>
<ul><li>Engine: Unity 6</li>
<li>Input: Unity's New Input System </li>
<li>Scriptable Objects: Used scriptable objects for efficient data management.</li>
<li>Architecture & Code Quality:
  <ul>
    <li>Service Locator and Dependency Injection Observer Pattern for event management</li>
    <li>Object Pooling for efficient obstacle/coin spawning</li>
  </ul>
</li>
</ul>
<p>Setup</p>
<ul><li>Clone the repository.</li>
<li>Open this project in Unity 6.1.x
<li>Press Play or Build to your target platform.</li>
</ul>
<p>Optimization Approach</p>
<ul>
<li>Object Pooling: Reused obstacle and coin objects instead of repeatedly instantiating and destroying them. This reduced memory allocation and minimized garbage collection overhead.</li>
<li>Physics Management: Confined physics-related logic to FixedUpdate and avoided unnecessary physics calculations. Rigidbody2D was used efficiently to simulate bouncing while keeping physics interactions lightweight.</li>
<li>Event-Driven Design: Applied the Observer Pattern to handle game events like player death event. This decoupled systems and reduced the need for constant checks or polling.This enhanced maintainability and allowed efficient communication between systems.</li>

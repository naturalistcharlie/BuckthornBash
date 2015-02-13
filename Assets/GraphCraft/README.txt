GraphCraft README
=================

GraphCraft is probably best understood by seeing it in action, even
just 30 seconds of action. Please see the
[GraphCraft in 30 Seconds](https://www.youtube.com/watch?v=UzL-bzD-J1w)
video.

GraphCraft is a Unity3D asset that uses graphs---constituted by vertices
and edges---to construct recursively-describable bodies.  This is a
hybrid approach between procedural generation and manual creation.
The graphs are created manually then used to automatically construct a
new procedurally generated object according to simple rules.  Unity3D
developers can design symmetric multi-segmented composable bodies using
the familiar Unity3D Editor tools.  The Graph Preview shows what
effects one's edits have in real-time.  The Graph Constructor
instantiates the game objects according to the graph.

Examples
--------

There are three examples:

1. The `Example Scene` shows progressively more complex graphs and
   their results.  a) The "Snake" shows a graph with one vertex and
   one edge that connects back to itself.  b) The "Tree" shows a graph
   with one vertex and two self-edges; the vertex also is a rigid body
   with a hinge joint with limits enabled so it sags after
   construction. c) The "Quadrapus" shows a composite reusing the
   "Snake" to create four legs.  It has a rigid body, hinge joint, and
   a script that causes its motors to flex sinusoidally. d) The
   humanoid has 3 vertices and 7 edges and shows how one complete
   design may be easily replicated into a "family" of different sizes.

2. The `Centipede Example` scene is the result of an introduction and
   tutorial video to GraphCraft made for
   [Mockup Monday #34](http://seawisphunter.com/mockup%20monday/2015/01/05/mockup-monday-34-graphcraft-for-unity3d/).

3. The `30 Seconds Example` scene is the resulting scene used in the
   video
   [GraphCraft in 30 Seconds](https://www.youtube.com/watch?v=UzL-bzD-J1w).

Usage
-----

GraphCraft exposes a set of tools under the menu
`Components->GraphCraft` that enables you to create graphs---that is
vertices and edges---in the Unity3D Editor.  To create a "Snake" from the `Example Scene` for example, one would do the following:

1. Create a cube.
2. Select the cube.
3. Add a vertex by selecting the menu item `Components->GraphCraft->Vertex`.
4. Add an edge connected to itself by selecting the menu item `Components->GraphCraft->Connect To Self`.
5. Add a preview by selecting the menu item `Components->GraphCraft->Preview Graph`.
6. Select the edge and scale, rotate, or translate it to one's liking.
7. Adjust the edge's count so that multiple segments of the snake will
be created.
8. Add a constructor by selecting the menu item `Components->GraphCraft->Construct Graph`.

Please see
[Mockup Monday #34](http://seawisphunter.com/mockup%20monday/2015/01/05/mockup-monday-34-graphcraft-for-unity3d/)
for a video tutorial.

Contact
-------

* twitter: [@shanecelis](https://twitter.com/shanecelis)
* website: [seawisphunter.com](http://seawisphunter.com)

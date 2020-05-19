# Review of Trees and Graphs

## Elementary Graph Algorithms

### Representations of graphs
1. The adjacency-list representation of a graph G = (V,E) consists of an array Adj of |V| lists, one for each vertex in V. For each u ∈ V , the adjacency list Adj[u] contains all the vertices v such that there is an edge (u,v) ∈ E. The adjacency-list representation provides a compact way to represent sparse graphs, those for which |E| is much less than |V|^2. 
2. For the adjacency-matrix representation of a graph G = (V,E) we assume that the vertices are numbered 1, 2, ... , |V| in some arbitrary manner. Then the adjacency-matrix representation of a graph G consists of a |V| * |V| matrix A = (aij) such that aij = 1 if (i,j) ∈ E, otherwise 0. 

### Breadth-First Search
1. Given a graph G = (V,E) and a distinguished source vertex s, breadth-first search systematically explores the edges of G to “discover” every vertex that is reachable from s.
2. ![BFS Algorithm](./images/BFS.png) 
Each vertex is initially white, is grayed when it is discovered in the search, and is blackened when it is finished.
3. Breadth-First Search runs in time linear in the size of the adjacency-list representation of G, that's **O(V+E)**.
4. Application: Find Shortest Distances from a given source.

### Depth-First Search
1. Depth-First Search timestamps each vertex. Each vertex v has two timestamps: the first timestamp v.d records when v is first discovered (and grayed), and the second timestamp v.f records when the search finishes examining v’s adjacency list (and blackens v). These timestamps are integers between 1 and 2|V|.
2. For every vertex u with u.d < u.f, vertex u is white before time u.d, gray between u.d and u.f, and black thereafter.
3. ![DFS Algorithm](./images/DFS.PNG)
4. The running time of DFS is Θ(V+E).   
5. Important Properties of DFS:
    1. Discovery and finishing times have parenthesis structure in DFS. Vertex v is a proper descendant of vertex u in the depth-first forest for a (directed or undirected) graph G if and only if **u.d < v.d < v.f < u.f**.
    2. Classification of edges:
        1. **Tree Edges**: Edge (u,v) is a tree edge if v was first discovered by exploring edge (u,v).
        2. **Back Edges**: edges (u,v) connecting a vertex u to an **ancestor** v in a depth-first tree. We consider self-loops, which may occur in directed graphs, to be back edges. 
        3. **Forward Edges**: nontree edges (u,v) connecting a vertex u to a **descendant** v in a depth-first tree.
        4. **Cross Edges**: all other edges. They can go between vertices in the same depth-first tree, as long as one vertex is not an ancestor of the other, or they can go between vertices in different depth-first trees.
    3. The key idea is that when we first explore an edge (u,v), the color of vertex v tells us something about the edge:
        1. WHITE indicates a tree edge
        2. Gray indicates a back edge
        3. Black indicates a forward or cross edge 
    4. In a DFS of an undirected graph G, every edge of G is either a tree edge or a back edge. Forward and cross edges never occur in a depth-first search of an undirected graph.     
    5. ![Edge Classifications](./images/Edges_Classification.png)



### Topological Sort
1. A topological sort of a dag (**directed acyclic graph**) G = (V,E) is a linear ordering of all its vertices such that if G contains an edge (u,v) then u appears before v in the ordering.
2. ![Topological Sort](./images/Topological_Sort.png)
3. Time complexity of Topological Sort is Θ(V+E). 
4. A directed graph G is acyclic if and only if a DFS of G yields no back edges.

### Strongly Connected Components
1. A strongly connected component of a directed graph G = (V,E) is a maximal set of vertices C ⊆ V such that for every pair of vertices u and v in C, we have both u -> v and v -> u; that is, vertices u and v are reachable from each other.

### Articulation Points and Bridges
1. Let G = (V,E) be a connected, undirected graph. An articulation point of G is a vertex whose removal disconnects G. A bridge of G is an edge whose removal disconnects G.
2. We can determine articulation points and bridges using depth-first search. Let G' = (V, E') be a depth-first tree of G.
    1. The root of G' is an articulation point of G if and only if it has at least two children in G'.
    2. Given a non-root vertex of G' v, v is an articulation point of G if and only if v has a child s such that there is no back edge from s or any descendant of s to a proper ancestor of v.
    3. How to compute all articulation points in O(E) time?
    4. An edge of G is a bridge if and only if it does not lie on any simple cycle of G.
    5. How to compute all the bridges of G in O(E) time?
3. [Algorithm Post](https://codeforces.com/blog/entry/71146)
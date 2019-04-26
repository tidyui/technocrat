/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using BlitCore;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Utility class for finding the path between to points in a room layout.
/// </summary>
public static class PathFinder
{
	/// <summary>
	/// Find the path in the room layout between the given points.
	/// </summary>
	/// <returns>The path</returns>
	/// <param name="layout">The room layout</param>
	/// <param name="start">The start point</param>
	/// <param name="end">The end point</param>
	public static List<Point> FindPath(Room[,] layout, Point start, Point end) {
		List<Point> visited = new List<Point> ();
		visited.Add (start);

		return VisitNodes (layout, visited, GetWalkableNeighbours (layout, visited, start), end);
	}

	/// <summary>
	/// Searches for a valid path starting from the given nodes.
	/// </summary>
	private static List<Point> VisitNodes(Room[,] layout, List<Point> visited, List<Point> nodes, Point end) {
		var paths = new List<List<Point>> ();

		foreach (var node in nodes) {
			visited.Add (node);

			if (node.x == end.x && node.y == end.y) {
				// This is the end node, add it to the list
				paths.Add (new List<Point> () { node });
			} else {
				// This is not the end node. Try to get the best path from 
				// the walkable neighbours
				var childPath = VisitNodes (layout, visited, GetWalkableNeighbours (layout, visited, node), end);
				if (childPath != null) {
					if (childPath.Any (p => p.x == end.x && p.y == end.y)) {
						childPath.Insert (0, node);
						paths.Add (childPath);
					}
				}
			}
		}

		// Get the most effective path from the list.
		List<Point> shortest = null;
		foreach (var path in paths) {
			if (shortest == null || path.Count < shortest.Count)
				shortest = path;
		}
		return shortest;
	}

	/// <summary>
	/// Gets the walkable neighbours available for the given position,
	/// excluding already visited nodes.
	/// </summary>
	private static List<Point> GetWalkableNeighbours(Room[,] layout, List<Point> visited, Point pos) {
		var neighbours = new List<Point> ();
		var current = layout [pos.x, pos.y];

        if (current.Exits.Any (e => e.Direction == ExitDirectionType.Top) && !visited.Contains (new Point (pos.x, pos.y + 1)))
			neighbours.Add (new Point (pos.x, pos.y + 1));
        if (current.Exits.Any (e => e.Direction == ExitDirectionType.Right) && !visited.Contains (new Point (pos.x + 1, pos.y)))
			neighbours.Add (new Point (pos.x + 1, pos.y));
        if (current.Exits.Any (e => e.Direction == ExitDirectionType.Bottom) && !visited.Contains (new Point (pos.x, pos.y - 1)))
			neighbours.Add (new Point (pos.x, pos.y - 1));
        if (current.Exits.Any (e => e.Direction == ExitDirectionType.Left) && !visited.Contains (new Point (pos.x - 1, pos.y)))
			neighbours.Add (new Point (pos.x - 1, pos.y));
		return neighbours;
	}
}

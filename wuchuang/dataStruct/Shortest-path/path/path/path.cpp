#include <iostream>
#include <queue>
#include "path.h"
using namespace std;

int main()
{
	
	Graph graph;
	queue<int>q;
	queue<int>p;
	int N, M;
	cin >> N >> M;

	graph.setEdge(M);
	graph.setVertex(N);
	for (int i = 0; i < M; i++)
	{
		int x, y;
		cin >> x >> y;
		graph.add(x, y);
	}
	

	graph.BL(N);

	
	return 0;
}
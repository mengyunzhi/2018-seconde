#include "AMLGraph.h"



void AMLGraph::init()
{
	// 输入节点数和边数
	cout <<"输入节点数和边数"<< endl;
	cin >> pointNum >> edgeNum;

	// 定义两顶点的编号
	int ivex, jvex;
	// 输入顶点的编号
	cout << "各边连通的两个顶点编号" << endl;

	for (int i = 0; i < edgeNum; i++) {
		cin >> ivex >> jvex;
		// 新建边
		Edge * edge = new Edge;
		// 设置边相连两顶点位置
		edge->ivex = ivex;
		edge->jvex = jvex;
		// 在表头插入边
		edge->ilink = points[ivex].firstEdge;
		edge->jlink = points[jvex].firstEdge;
		points[ivex].firstEdge = edge;
		points[jvex].firstEdge = edge;
	}
}
// 深度优先搜索
void AMLGraph::depth_First_Search(int num, string & pointSequence, string & edgeSequence)
{
	int jvex;
	Edge * edge;
	// 遍历的点序列
	pointSequence += to_string(num) + " ";

	points[num].ifvisited = true;
	
	edge = points[num].firstEdge;

	while (edge)
	{
		// 遍历边的另外一顶点
		jvex = edge->ivex == num ? edge->jvex : edge->ivex;
		// 查看这个顶点是否被访问过
		if (!points[jvex].ifvisited) {
			// 遍历的边集合，以弧头弧尾表示
			edgeSequence += "(" + to_string(num) + "," + to_string(jvex) + ")";
			// 继续遍历这个顶点相连的其他的顶点
			depth_First_Search(jvex, pointSequence, edgeSequence);
		}
		// 遍历另外一条边
		edge = edge->ivex == num ? edge->ilink : edge->jlink;
	}
}

void AMLGraph::printDFSSe(int num)
{
	string DFSPointSe = "深度优先搜索点序列:", DFSEdgeSe = "深度优先搜索边集:";
	depth_First_Search(num, DFSPointSe, DFSEdgeSe);
	cout << DFSPointSe << endl;
	cout << DFSEdgeSe << endl;
}

void AMLGraph::Breadth_First_Search(int num)
{
	queue<int> queue;
	string pointSe = "广度优先搜索点序列:";
	string edgeSe = "深度优先搜索边集:";
	points[num].ifvisited = true;

	pointSe += to_string(num) + " "; 
	queue.push(num);
	while (!queue.empty())
	{
		// 队头元素出列并置为temp
		int temp = queue.front();
		queue.pop();

		for (int i = firstAdjVex(temp); i > 0; i = nextAdjVex(temp, i)) {
			if (!points[i].ifvisited) {
				points[i].ifvisited = true;
				pointSe += to_string(i) + " ";
				edgeSe += "(" + to_string(temp) + "," + to_string(i) + ")";
				queue.push(i);
			}
		}
	}

	cout << pointSe << endl;
	cout << edgeSe << endl;
}

void AMLGraph::resetVisited()
{
	map<int, Point>::iterator it;
	for(it = points.begin(); it != points.end(); it++)
		it->second.ifvisited = false;
}

int AMLGraph::firstAdjVex(int num)
{
	int first;
	points[num].firstEdge->ivex == num ? first =  points[num].firstEdge->jvex : first = points[num].firstEdge->ivex;
	return first;
}

int AMLGraph::nextAdjVex(int num, int first)
{
	int next = 0;// num相对于first的下一个相连的顶点
	vector<int> adj = adjPoints(num);// num所有相邻顶点的编号

	for (int i = 0; i < adj.size() - 1; i++)
	{
		if (adj[i] == first) { next = adj[i + 1]; break; }
	}
	return next;
}

vector<int> AMLGraph::adjPoints(int num)
{
	vector<int> adjPointsNum;// 相连顶点的编号数组
	Edge * p = points[num].firstEdge;
	while (p)
	{
		if (p->ivex == num) {
			adjPointsNum.push_back(p->jvex);
			p = p->ilink;
		} else {
			adjPointsNum.push_back(p->ivex);
			p = p->jlink;
		}
	}
	return adjPointsNum;
}

AMLGraph::AMLGraph()
{
	edgeNum = 0;
	pointNum = 0;
}


AMLGraph::~AMLGraph()
{
}

Point::Point()
{
	ifvisited = false;
	data = "";
	firstEdge = NULL;
}

Edge::Edge()
{
	ivex = -1;
	ilink = NULL;
	jlink = NULL;
	jvex = -1;
	weight = -1;
}

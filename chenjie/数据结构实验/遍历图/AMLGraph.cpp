#include "AMLGraph.h"



void AMLGraph::init()
{
	// ����ڵ����ͱ���
	cout <<"����ڵ����ͱ���"<< endl;
	cin >> pointNum >> edgeNum;

	// ����������ı��
	int ivex, jvex;
	// ���붥��ı��
	cout << "������ͨ������������" << endl;

	for (int i = 0; i < edgeNum; i++) {
		cin >> ivex >> jvex;
		// �½���
		Edge * edge = new Edge;
		// ���ñ�����������λ��
		edge->ivex = ivex;
		edge->jvex = jvex;
		// �ڱ�ͷ�����
		edge->ilink = points[ivex].firstEdge;
		edge->jlink = points[jvex].firstEdge;
		points[ivex].firstEdge = edge;
		points[jvex].firstEdge = edge;
	}
}
// �����������
void AMLGraph::depth_First_Search(int num, string & pointSequence, string & edgeSequence)
{
	int jvex;
	Edge * edge;
	// �����ĵ�����
	pointSequence += to_string(num) + " ";

	points[num].ifvisited = true;
	
	edge = points[num].firstEdge;

	while (edge)
	{
		// �����ߵ�����һ����
		jvex = edge->ivex == num ? edge->jvex : edge->ivex;
		// �鿴��������Ƿ񱻷��ʹ�
		if (!points[jvex].ifvisited) {
			// �����ı߼��ϣ��Ի�ͷ��β��ʾ
			edgeSequence += "(" + to_string(num) + "," + to_string(jvex) + ")";
			// ��������������������������Ķ���
			depth_First_Search(jvex, pointSequence, edgeSequence);
		}
		// ��������һ����
		edge = edge->ivex == num ? edge->ilink : edge->jlink;
	}
}

void AMLGraph::printDFSSe(int num)
{
	string DFSPointSe = "�����������������:", DFSEdgeSe = "������������߼�:";
	depth_First_Search(num, DFSPointSe, DFSEdgeSe);
	cout << DFSPointSe << endl;
	cout << DFSEdgeSe << endl;
}

void AMLGraph::Breadth_First_Search(int num)
{
	queue<int> queue;
	string pointSe = "�����������������:";
	string edgeSe = "������������߼�:";
	points[num].ifvisited = true;

	pointSe += to_string(num) + " "; 
	queue.push(num);
	while (!queue.empty())
	{
		// ��ͷԪ�س��в���Ϊtemp
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
	int next = 0;// num�����first����һ�������Ķ���
	vector<int> adj = adjPoints(num);// num�������ڶ���ı��

	for (int i = 0; i < adj.size() - 1; i++)
	{
		if (adj[i] == first) { next = adj[i + 1]; break; }
	}
	return next;
}

vector<int> AMLGraph::adjPoints(int num)
{
	vector<int> adjPointsNum;// ��������ı������
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

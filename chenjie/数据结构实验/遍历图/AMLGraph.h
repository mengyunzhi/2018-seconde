#pragma once
#include <string>
#include <iostream>
#include <Map>
#include <queue>
#include <vector>
using namespace std;
class Edge;
// ��
class Point
{
private:
	string data;// ����
	Edge * firstEdge;// ��õ������ĵ�һ����
	bool ifvisited;// �Ƿ񱻷��ʹ�
	friend class AMLGraph;
	friend class AMLGraph;
public:
	Point();
};
// ��
class Edge
{
public:
	int ivex, jvex;// �����������������λ��
	Edge * ilink, *jlink;// i����������һ���ߺ�j��������дһ����
	int weight;// �ñߵ�Ȩ��
	friend class Point;
	Edge();
};
// ����ͼ
class AMLGraph
{
private:
	map<int, Point> points;		// ����ͼ�Ķ��㼰��Ӧ�ı��
	int pointNum, edgeNum;		// ����ͼ�������ͱ���
public:
	void init();			   // ���붥�����������ͱ��������������ţ���������ͼ�Ķ����ڽ�����
	void depth_First_Search(int num, string & pointSequence, string & edgeSequence);// �Ա��Ϊnum�Ķ�����������������
	void printDFSSe(int num);// ��ӡ���Ϊnum������������������еĵ����кͱ߼�
	void Breadth_First_Search(int num);// �Ա��Ϊnum�Ķ�����й����������,����ӡ���������еĵ����кͱ߼�
	void resetVisited();// ���õ�ķ���״̬
	int firstAdjVex(int num);// ���ر��Ϊnum�Ķ���ĵ�һ����������ı��
	int nextAdjVex(int num, int first);// ����num�����first�������һ�������Ķ���ı��
	vector<int> adjPoints(int num);// ���ر��Ϊnum�Ķ������������ж���������

	AMLGraph();
	~AMLGraph();
};


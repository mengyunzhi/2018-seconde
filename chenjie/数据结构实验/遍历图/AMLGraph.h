#pragma once
#include <string>
#include <iostream>
#include <Map>
#include <queue>
#include <vector>
using namespace std;
class Edge;
// 点
class Point
{
private:
	string data;// 数据
	Edge * firstEdge;// 与该点相连的第一条边
	bool ifvisited;// 是否被访问过
	friend class AMLGraph;
	friend class AMLGraph;
public:
	Point();
};
// 边
class Edge
{
public:
	int ivex, jvex;// 这条边连的两个点的位置
	Edge * ilink, *jlink;// i点相连的下一条边和j点相连的写一条边
	int weight;// 该边的权重
	friend class Point;
	Edge();
};
// 无向图
class AMLGraph
{
private:
	map<int, Point> points;		// 无向图的顶点及对应的编号
	int pointNum, edgeNum;		// 无向图顶点数和边数
public:
	void init();			   // 输入顶点数，边数和边相连的两顶点编号，生成无向图的多重邻接链表
	void depth_First_Search(int num, string & pointSequence, string & edgeSequence);// 对编号为num的顶点进行深度优先搜索
	void printDFSSe(int num);// 打印编号为num的深度优先搜索过程中的点序列和边集
	void Breadth_First_Search(int num);// 对编号为num的顶点进行广度优先搜索,并打印搜索过程中的点序列和边集
	void resetVisited();// 重置点的访问状态
	int firstAdjVex(int num);// 返回编号为num的顶点的第一个相连顶点的编号
	int nextAdjVex(int num, int first);// 返回num相对于first顶点的下一个相连的顶点的编号
	vector<int> adjPoints(int num);// 返回编号为num的顶点相连的所有顶点编号数组

	AMLGraph();
	~AMLGraph();
};


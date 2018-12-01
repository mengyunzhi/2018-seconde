#pragma once
#include <vector>
#include <map>
#include <string>
#include <iostream>
#include <algorithm>
#include <fstream>
#include "stdio.h"
using namespace std;
class Node
{
public:
	Node(char c, int w) {
		weight = w;
		parent = lchild = rchild = 0;
		code = c;
	};

	Node() {
		weight = parent = lchild = rchild = 0;
		code = '0';
	};

private:
	char code;
	int weight;
	int parent, lchild, rchild;
	friend class HuffmanTree;
};
class HuffmanTree
{
public:
	HuffmanTree(int leaf_number);	// 将键盘读入的字符及权存到huTree中
	void generateHuCode();			// 生成哈夫曼树
	void saveHuTree();				// 将哈夫曼树存到文件当中
	void saveHuCode();				// 将哈夫曼编码存到文件当中
	void enCoding();				// 生成哈夫曼编码表
	void codeing();					// 编码
	void deCoding();				// 译码
	int findMinLeaf();				// 寻找权值最小的叶子节点，并返回它的位置
	void treePrinting(int & postion, string str);// 直观地显示哈夫曼树
	bool findKeyByValue(string value, char & key);
private:
	vector<Node> huTree;// 哈夫曼树
	map<char, string> huCode;// 哈夫曼编码,char为字符，string为对应的编码
	int leaf_number;
};

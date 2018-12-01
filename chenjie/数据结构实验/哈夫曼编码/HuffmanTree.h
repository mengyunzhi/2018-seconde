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
	HuffmanTree(int leaf_number);	// �����̶�����ַ���Ȩ�浽huTree��
	void generateHuCode();			// ���ɹ�������
	void saveHuTree();				// �����������浽�ļ�����
	void saveHuCode();				// ������������浽�ļ�����
	void enCoding();				// ���ɹ����������
	void codeing();					// ����
	void deCoding();				// ����
	int findMinLeaf();				// Ѱ��Ȩֵ��С��Ҷ�ӽڵ㣬����������λ��
	void treePrinting(int & postion, string str);// ֱ�۵���ʾ��������
	bool findKeyByValue(string value, char & key);
private:
	vector<Node> huTree;// ��������
	map<char, string> huCode;// ����������,charΪ�ַ���stringΪ��Ӧ�ı���
	int leaf_number;
};

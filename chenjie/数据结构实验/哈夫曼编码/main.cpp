#include <iostream>
#include "HuffmanTree.h"
using namespace std;
int main()
{ 
	// 初始化哈夫曼树
	HuffmanTree huffmanTree(27);
	// 生成哈夫曼树
	huffmanTree.generateHuCode();
	// 生成哈夫曼编码
	huffmanTree.enCoding();
	// 保存哈夫曼树和哈夫曼编码到文件中
	huffmanTree.saveHuTree();
	huffmanTree.saveHuCode();
	// 编码
	huffmanTree.codeing();
	// 译码
	huffmanTree.deCoding();
	// 以凹入表输出哈夫曼树
	int a = 53;
	string str;
	huffmanTree.treePrinting(a, str);
	return 0;
}
package com.company.service;

import com.company.entity.MazeElement;

import java.util.ArrayList;


public interface Maze <E extends MazeElement>{
	ArrayList<ArrayList<E>> init(ArrayList<ArrayList<E>> maze, int size, int obstacleNumber);//��ʼ��һ��4*4���Թ�
	void show();//��ʾ�Թ�
	boolean getAnswer(E element);//����Թ��ⷨ
	E move(int x, int y);//����λ���ƶ�Ԫ��
}

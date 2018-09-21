package com.company;

import com.company.entity.Element;
import com.company.service.MazeImp;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    static final int size = 4;
    static final int obstacleNumber = 4;
    static Scanner sc = new Scanner(System.in);
    public static void main(String []args) {
        MazeImp<Element> maze = new MazeImp<Element>();
        int number = 0;
        System.out.println("输入1开始迷宫,输入2查看迷宫答案,输入3退出");
        System.out.println("@代表起点,!代表终点,#代表障碍,-代表可通过路径,* 代表答案路径");
        while(number != 3) {
            number = sc.nextInt();
            switch(number) {
                case 1: maze.init(newMaze(size), size, obstacleNumber);System.out.println("新迷宫");maze.show();break;
                case 2: maze.getAnswer(maze.getStart());System.out.println("迷宫答案");;maze.show();break;
                case 3:break;
            }
        }
    }
    public static ArrayList<ArrayList<Element>>  newMaze(int size) {
        ArrayList<ArrayList<Element>> list = new ArrayList<ArrayList<Element>>();
        for (int j = 0;j < size; j++) {
            ArrayList<Element> line = new ArrayList<Element>();
            for (int i = 0; i < size; i++) {
                Element element = new Element();
                element.setPosition(i, j);
                line.add(element);
            }
            list.add(line);
        }
        return list;
    }
}

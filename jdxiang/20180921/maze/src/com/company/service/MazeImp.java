package com.company.service;

import java.util.ArrayList;

import com.company.entity.Element;
import com.company.entity.MazeElement;


public class MazeImp<E extends MazeElement> implements Maze<E>{
	private ArrayList<ArrayList<E>> maze;
	E start;
	E end;
	int size;
	@Override
	public ArrayList<ArrayList<E>> init(ArrayList<ArrayList<E>> maze, int size, int obstacleNumber) {
		// TODO Auto-generated method stub
		//����������
		int startX = (int) (Math.random() * size);
		int startY = (int)(Math.random() * size);
		E start = (E)maze.get(startY).get(startX);
		start.setStatus("start");
		this.start = start;
		//��������յ�
		int endlX = 0;
		int endlY = 0;
		E end = null;
		do {
			endlX = (int) (Math.random() * size);
			endlY = (int) (Math.random() * size);
			end = (E)maze.get(endlY).get(endlX);
		} while(end.equals(start));
		end.setStatus("endl");
		this.end = end;
		//��������ĸ��ϰ�
		int number = 0;
		while(number < obstacleNumber) {
			
			int obstacleX = (int) (Math.random() * size);
			int obstacleY = (int) (Math.random() * size);
			E obstacle = maze.get(obstacleY).get(obstacleX);
				if (!obstacle.equals(start) && !obstacle.equals(end)) {
					if (obstacle.getStatus() != null) {
						if (obstacle.getStatus().equals("obstacle")) {
							continue;
						}
					} else {
						number++;
						obstacle.setStatus("obstacle");
					}
				}
		}
		this.maze = maze;
		this.size = size;
		return maze;
	}

	@Override
	public void show() {
		// TODO Auto-generated method stub
		for (ArrayList<E> l : this.maze) {
			for (E element : l) {
				if(element.getStatus() != null) {
					if (element.getStatus().equals("start")) {
						System.out.print("@ ");
					} else if (element.getStatus().equals("endl")) {
						System.out.print("! ");
					} else if (element.getStatus().equals("existen")) {
						System.out.print("* ");
					} else if (element.getStatus().equals("obstacle")) {
						System.out.print("# ");
					} else {
						System.out.print("- ");
					}
				} else {
					System.out.print("- ");
				}
			}
			System.out.println("");
		}
	}

	@Override
	public boolean getAnswer(E element) {
		// TODO Auto-generated method stub
		//若为最后一个结束
		if (element.equals(end)) {return true;}
		E next = element;
		//向上移动
		if ((next = this.move(element.getX(), element.getY() - 1)) != null && !next.equals(start) ) {
			if (!next.equals(this.end)) {
				next.setStatus("existen");
			}
			next.setRoute("向上");
			if(this.getAnswer(next)) {return true;}
		}
		
		//向左移动
		if ((next = this.move(element.getX() - 1, element.getY())) != null && !next.equals(start) ) {
			next.setRoute("向左");
			if (!next.equals(this.end)) {
				next.setStatus("existen");
			}
			if(this.getAnswer(next)) {return true;}
		}
		//向下移动
		if ((next = this.move(element.getX(), element.getY() + 1)) != null && !next.equals(start) ) {
			next.setRoute("向下");
			if (!next.equals(this.end)) {
				next.setStatus("existen");
			}
			if(this.getAnswer(next)) {return true;}
		}
		//向右移动
		if ((next = this.move(element.getX() + 1, element.getY())) != null && !next.equals(start)) {
			next.setRoute("向右");
			if (!next.equals(this.end)) {
				next.setStatus("existen");
			}
			if(this.getAnswer(next)) {return true;}
		}
		
		if (!element.equals(start)) {
			element.setStatus(null);
			element.setRoute(null);
		}
		return false;
	}

	@Override
	public E move(int x ,int y) {
		// TODO Auto-generated method stub
	 	if (x < this.size && y < this.size && x >= 0 && y >= 0) {
	 		Element e = (Element) maze.get(y).get(x);
	 		if (e.getStatus() == null || e.equals(this.end)) {
		 		return (E) e;
		 	}
	 	}
		return null;
	}
	public E getStart() {
		return this.start;
	}
	public ArrayList<ArrayList<E>> getMaze() {
		return this.maze;
	}
}

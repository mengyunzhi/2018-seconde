package com.company.entity;

public interface MazeElement <E>{
	void setPosition(int x, int y);
	void setStatus(String status);
	void setRoute(String route);
	String getStatus();
	int getX();
	int getY();
}

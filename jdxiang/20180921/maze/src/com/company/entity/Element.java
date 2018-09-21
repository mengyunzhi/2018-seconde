package com.company.entity;

public class Element implements MazeElement<Element>{
	int x;
	int y;
	String status;
	String route;
	@Override
	public void setPosition(int x, int y) {
		// TODO Auto-generated method stub
		this.x = x;
		this.y = y;
	}

	@Override
	public void setStatus(String status) {
		// TODO Auto-generated method stub
		this.status = status;
	}

	@Override
	public void setRoute(String route) {
		// TODO Auto-generated method stub
		this.route = route;
	}

	@Override
	public String getStatus() {
		// TODO Auto-generated method stub
		return this.status;
	}

	@Override
	public int getX() {
		// TODO Auto-generated method stub
		return this.x;
	}

	@Override
	public int getY() {
		// TODO Auto-generated method stub
		return this.y;
	}
	
}

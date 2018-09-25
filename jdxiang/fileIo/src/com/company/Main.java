package com.company;

import com.company.service.FileService;
import com.company.service.FileServiceImpl;

import java.io.File;
import java.io.IOException;

public class Main {

    public static void main(String[] args) throws IOException {
	// write your code here
        FileService fileService = new FileServiceImpl();
        fileService.copyFile("/home/h123123/桌面/C/start", "/home/h123123/桌面/C/start2");

    }
}

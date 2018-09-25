package com.company.service;

import java.io.*;

public class FileServiceImpl implements FileService {
    @Override
    public void sayAllFileName(File file) {
        if (!file.exists()) {
            return;
        }
        if (!file.isDirectory()) {
            return;
        }
        File[] files = file.listFiles();
        if (files != null && files.length != 0) {
            for (File file1: files) {
                if (file1.isDirectory()) {
                    sayAllFileName(file1);
                } else {
                    System.out.println(file1.toString());
                }
            }
        }
    }

    @Override
    public void copyFile(String customary, String copyName) throws IOException {
        FileInputStream fileInputStream = new FileInputStream(customary);
        FileOutputStream fileOutputStream = new FileOutputStream(copyName);
        int bytes = 0;
        while(bytes != -1) {
            bytes = fileInputStream.read();
            if (bytes != -1) {
                fileOutputStream.write(bytes);
            }
        }
        fileInputStream.close();
        fileOutputStream.close();
    }
}

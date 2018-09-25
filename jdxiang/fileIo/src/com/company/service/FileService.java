package com.company.service;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

public interface FileService {
    void sayAllFileName(File file);
    void copyFile(String customary, String copyName) throws IOException;
}

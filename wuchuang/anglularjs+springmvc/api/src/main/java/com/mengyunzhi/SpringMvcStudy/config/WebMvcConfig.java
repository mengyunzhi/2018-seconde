package com.mengyunzhi.SpringMvcStudy.config;

import org.springframework.context.annotation.Bean;
import org.springframework.stereotype.Component;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

@Component
public class WebMvcConfig {
    // 声明一个Bean，SpringMVC在启动的时候会按这个进行配置
    @Bean
    public WebMvcConfigurer corsConfigurer() {
        return new WebMvcConfigurerAdapter() {
            @Override
            public void addCorsMappings(CorsRegistry registry) {
                registry.addMapping("/**").allowedOrigins("http://localhost:9000")
                        .allowedMethods("GET", "PUT", "POST", "PATCH", "OPTIONS", "DELETE");
            }
        };
    }
}

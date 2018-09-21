package com.mengyunzhi.SpringMvcStudy;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

@SpringBootApplication
public class SpringMvcStudyApplication {

	public static void main(String[] args) {
		SpringApplication.run(SpringMvcStudyApplication.class, args);
	}
	//声明一个Bean，springMVC在启动时，会自动打锚这个Bean，并按照这个Bean的配置进行一些配置
	@Bean
	public WebMvcConfigurer corsConfigurer() {
		return  new WebMvcConfigurerAdapter() {
			@Override
			public void addCorsMappings(CorsRegistry registry) {
				//添加一个映射 /Teacher
				//此映射允许进行CORS的地址为：http://localhost:9000
				registry.addMapping("/**").allowedOrigins("http://localhost:9000")
				.allowedMethods("GET","POST","DELETE","PUT","PATCH","OPTIONS");
			}
		};
	}
}

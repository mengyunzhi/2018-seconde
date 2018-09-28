package www.mengyunzhi.pratice.config;

import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

/**
 * @author liyiheng
 * @date 2018/9/28 19:44
 */

//Some settings for spring
public class WebMvcConfig {
    //Declare that a Bean. Spring MVC will automatically anchor the BEAN at startup and configure it as configured
    @Bean
    public WebMvcConfigurer corsConfigurer() {
        return new WebMvcConfigurerAdapter() {
            @Override
            public void addCorsMappings(CorsRegistry registry) {
                //this mapping allows the address of CORS to be:http://localhost:9000
                registry.addMapping("/**").allowedOrigins("http://localhost:9000")
                        .allowedMethods("GET", "POST", "DELETE", "PUT", "PATCH", "OPTIONS");
            }
        };
    }
}

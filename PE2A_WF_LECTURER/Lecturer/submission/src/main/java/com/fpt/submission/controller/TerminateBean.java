package com.fpt.submission.controller;

import javax.annotation.PreDestroy;

public class TerminateBean {
    @PreDestroy
    public void onDestroy() throws Exception {
        System.out.println("Spring Container is destroyed!");
    }
}

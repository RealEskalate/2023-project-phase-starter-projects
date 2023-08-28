"use client";
import SmallBlogCard from "@/components/blog/SmallBlogCard";
import { Blog } from "@/types/blog/blog";
import React from "react";

const MyBlogs = () => {
  const bloggg: Blog[] = [
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
    {
      _id: "64dfe9dd50d83607285ffa10",
      image:
        "https://res.cloudinary.com/djtkzulun/image/upload/v1692395995/A2sv/c6fnsnngdrjrrvxv8xos.jpg",
      title: "Mastering the Art of Code Refactoring 2",
      description:
        "Code refactoring is an essential practice in software development that often separates novice programmers from experienced engineers. Refactoring isn't just about tidying up your code; it's about improving its structure, readability, and maintainability. Let's delve into the key aspects of mastering the art of code refactoring.",
      author: {
        _id: "64dfe6fb50961c55ce93e7de",
        name: "Bruk Mekonen",
        email: "bruk@gmail.com",
        image:
          "https://res.cloudinary.com/djtkzulun/image/upload/v1684307248/Portfolio/dgxjqlgpys1imwnw2bhq.png",
        role: "user",
      },
      isPending: true,
      tags: ["Programming", "Code"],
      likes: 0,
      relatedBlogs: [],
      skills: ["Web Development", "Mobile"],
      createdAt: "2023-08-18T21:59:57.206Z",
      updatedAt: "2023-08-18T21:59:57.206Z",
      __v: 0,
    },
  ];

  return (
    <div className="mb-32">
    <div className=" py-10 text-blog_list_sub_text_color  ">
      <p className="text-xl  font-bold">Manage Blogs</p>
      <p className="text-sm">
        Edit, Delete and View the Status of your blogs
      </p>
    </div>
    <hr className="py-1" />
    <SmallBlogCard blogs={bloggg} />
  </div>
  );
};

export default MyBlogs;

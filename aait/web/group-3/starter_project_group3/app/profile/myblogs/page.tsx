"use client";
import Image from "next/image";
import React from "react";

const MyBlogs = () => {
  const blogsList = [
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
    },
    {
      image: "assets/blogInvidualImage.svg",
      header: "Design Liberalized Exchange Rate Management",
      personImage: "/assets/cardPersonImage.svg",
      personName: "Fred Boone",
      date: "Jan 10, 2020",
      skills: ["UI/UX", "DEVELOPMENT"],
      content:
        "A little personality goes a long way, especially on a business blog. So don’t be afraid to let loose.",
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
      <div className="  py-4 flex justify-between items-center flex-wrap gap-y-8">
        {blogsList.map((blog) => (
          <div key={blog.header} className=" w-[23%]">
            <div className=" flex justify-center items-center">
              <Image
                src={blog.image}
                alt="blog image"
                width={350}
                height={350}
                // fill
              />
            </div>
            <p className="font-bold text-nav_text_color mx-5 py-3">
              {blog.header}
            </p>
            <p className="flex mx-5  pt-3 pb-5 justify-start gap-x-2 items-center">
              <Image
                src={blog.personImage}
                alt="blog image"
                width={20}
                height={20}
              />
              by
              <span className="text-nav_text_color font-bold">
                {blog.personName}{" "}
              </span>
              <span className="text-sm font-light text-blog_icons_text_color">
                {blog.date}
              </span>
            </p>

            <div className="flex justify-center pb-5">
              {blog.skills.map((skill) => (
                <span
                  key={skill}
                  className="text-xs font-medium mx-3 text-[#8E8E8E]   bg-[#F5F5F5] py-1 px-3 rounded-lg"
                >
                  {skill}
                </span>
              ))}
            </div>

            <p className="text-[12px]  pb-5  text-[#8E8E8E]">{blog.content}</p>

            <p className="flex justify-between items-center mx-1">
              <span className="flex  gap-x-2">
                <Image
                  src={"assets/pendingClock.svg"}
                  alt="blog image"
                  width={20}
                  height={20}
                />
                <span className="text-sm text-blog_pending_icon_text_color font-bold">
                  Pending
                </span>
              </span>

              <button className="text-primary font-bold ">Read More</button>
            </p>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MyBlogs;

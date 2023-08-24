'use client';
import { Blog, User } from '@/lib/types';
import React, { useEffect, useState } from 'react';
import SingleBlogCard from '../components/SingleBlogCard';
import { useGetBlogsQuery } from '@/lib/redux/slices/blogsApi';

const startingId = 10;

const users: User[] = [
  {
    name: 'Emily Johnson',
    role: 'Content Marketing Manager',
    picture: `https://picsum.photos/id/${startingId}/300/300`,
  },
  {
    name: 'Michael Carter',
    role: 'Freelance Photographer',
    picture: `https://picsum.photos/id/${startingId + 1}/300/300`,
  },
  {
    name: 'Sophia Lee',
    role: 'Fitness Coach and Nutritionist',
    picture: `https://picsum.photos/id/${startingId + 2}/300/300`,
  },
  {
    name: 'David Miller',
    role: 'Tech Enthusiast and Blogger',
    picture: `https://picsum.photos/id/${startingId + 3}/300/300`,
  },
  {
    name: 'Lillian Chen',
    role: 'Travel Blogger and Adventurer',
    picture: `https://picsum.photos/id/${startingId + 4}/300/300`,
  },
];

const blogs: Blog[] = [
  {
    author: users[0],
    date: '2023-08-22',
    blog_title: 'The Art of Storytelling: Crafting Compelling Narratives',
    excerpt:
      'Discover the magic behind crafting stories that captivate your audience and leave a lasting impact. Learn key techniques to elevate your storytelling game.',
    tags: ['Storytelling', 'Content Creation', 'Narratives'],
    cover_image: `https://picsum.photos/id/${startingId + 5}/300/200`,
  },
  {
    author: users[1],
    date: '2023-07-15',
    blog_title: 'Capturing Moments: The Essence of Photography',
    excerpt:
      'Explore the art of photography and how a single click can immortalize a moment. Dive into techniques that can turn your snapshots into masterpieces.',
    tags: ['Photography', 'Visual Arts', 'Composition'],
    cover_image: `https://picsum.photos/id/${startingId + 6}/300/200`,
  },
  {
    author: users[2],
    date: '2023-09-05',
    blog_title: 'Fuel Your Fitness: Nutrition Tips for a Healthier You',
    excerpt:
      'Uncover the secrets of maintaining a balanced diet that complements your fitness journey. Get insights from a seasoned fitness coach and nutritionist.',
    tags: ['Fitness', 'Nutrition', 'Wellness'],
    cover_image: `https://picsum.photos/id/${startingId + 7}/300/200`,
  },
  {
    author: users[3],
    date: '2023-06-10',
    blog_title: 'Exploring AI: The Present and Future of Artificial Intelligence',
    excerpt:
      'Delve into the world of artificial intelligence, from its origins to the cutting-edge applications shaping industries. Gain insights into its future potential.',
    tags: ['Artificial Intelligence', 'Technology', 'Innovation'],
    cover_image: `https://picsum.photos/id/${startingId + 8}/300/200`,
  },
  {
    author: users[4],
    date: '2023-04-03',
    blog_title: 'Wanderlust Chronicles: Tales from Remote Corners of the Earth',
    excerpt:
      'Embark on a virtual journey to breathtaking landscapes and cultural encounters. Join the travel blogger Lillian as she shares her extraordinary experiences.',
    tags: ['Travel', 'Adventure', 'Cultural Exploration'],
    cover_image: `https://picsum.photos/id/${startingId + 9}/300/200`,
  },
];

// The 'blogs' array now contains all the sample blog entries grouped together.

const Page: React.FC = () => {
  const { data: blogs, error, isLoading, isSuccess } = useGetBlogsQuery();
  console.log('====================================');
  console.log(blogs);
  console.log('====================================');

  return (
    <div className="w-full font-secondaryFont mt-20 flex flex-col justify-center items-center">
      {/* search section */}
      <div className="w-full flex flex-col lg:flex-row items-center justify-between lg:px-24 px-10 gap-10 lg:gap-0">
        <h2 className="text-2xl  font-semibold">Blogs</h2>
        <div className="flex gap-5">
          <input
            type="text"
            name="search"
            placeholder="Search..."
            className="border px-4 lg:px-10 py-2 rounded-3xl text-sm"
          />
          <button className="bg-primaryColor text-white px-6 py-4 rounded-3xl text-xs lg:text-sm font-semibold">
            + New Blog
          </button>
        </div>
        <div className=""></div>
      </div>

      {/* blog list */}
      <div className="flex flex-col gap-4 lg:px-52 md:px-40 px-8 mt-5">
        {blogs?.map((blog: Blog, index: number) => (
          <>
            <hr className="mt-4 mb-6 bg-textColor-100 w-3/4" />
            <SingleBlogCard key={index} {...blog} />
          </>
        ))}
      </div>
    </div>
  );
};

export default Page;

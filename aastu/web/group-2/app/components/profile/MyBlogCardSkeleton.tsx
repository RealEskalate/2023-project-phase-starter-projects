import React from 'react';
import SmallBlogCardSkeleton from '../blog/SmallBlogCardSkeleton';

const MyBlogCardSkeleton = () => {
  const blogs = new Array(6).fill(0);
  return (
    <div className="grid font-secondaryFont mb-12 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-4">
      {blogs.map((_, index) => (
        <SmallBlogCardSkeleton key={index} />
      ))}
    </div>
  );
};

export default MyBlogCardSkeleton;

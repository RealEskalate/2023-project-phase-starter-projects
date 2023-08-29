import React from 'react';
import Image from 'next/image';
// import First from '@/app/blog/SingleBlog/[id]/page';
import Link from 'next/link';

interface SingleBlogProps {
  id: string;
  image: string;
  authorName: string;
  title: string;
  tags: string[];
  descrip: string;
  likes: number;
  profilePic: string;
}

const SingleBlog: React.FC<SingleBlogProps> = ({
  id,
  image,
  authorName,
  title,
  tags,
  descrip,
  likes,
  profilePic,
}) => {
  const firstPeriodIndex = descrip.indexOf('.');
  const firstSentence = firstPeriodIndex !== -1 ? descrip.slice(0, firstPeriodIndex + 1) : descrip;
  console.log(authorName);

  return (
    <div className="transition-all ease-linear m-5 w-80 shadow cursor-pointer hover:shadow dark:hover:shadow-slate-700  rounded-md dark:bg-dark-backgroundLight  font-primaryFont">
      <div>
        <Image src={image} width={320} height={200} alt="Picture" className="rounded-t-md" />
      </div>
      <div className="p-4">
        <div className="font-mont font-medium text-base text-gray-700 dark:text-dark-textColor-100">
          {title}
        </div>

        {authorName && (
          <div>
            <div className="flex my-4">
              <Image
                src={profilePic}
                width={28}
                height={28}
                alt="Picture"
                className="rounded-full"
              />
              <div className="font-mont flex">
                <div className="font-extralight text-gray-300 mx-2 text-xs p-1">by</div>
                <div className="font-semibold text-gray-500 text-xs p-1">{authorName}</div>
                <div className="text-gray-300">&nbsp;&nbsp;|&nbsp;&nbsp;</div>
                <div className="text-xs p-1 text-gray-300">Jan 20, 2021</div>
              </div>
            </div>
          </div>
        )}

        <div className="flex">
          {tags.map((tag: string) => {
            return (
              <div className="bg-gray-200 rounded-full m-4 px-6 py-2 font-mont text-xs text-gray-600 dark:bg-dark-background dark:text-dark-textColor-50">
                {tag}
              </div>
            );
          })}
        </div>
        <div className="text-sm font-mont text-gray-500 dark:text-dark-textColor-50">
          {firstSentence}
        </div>
        <hr className="my-6 bg-gray-100 border border-gray-200"></hr>
        <div className="flex">
          <Image src="/message-square.svg" width={22} height={22} alt="Picture" className="mr-4" />
          <div className="text-xs font-mont font-semibold text-gray-600">{likes} Likes</div>
          <Link href={`../../blog/singleBlog/${id}`}>
            <div className="font-mont text-xs text-indigo-600 ml-32 font-semibold">Read More</div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default SingleBlog;

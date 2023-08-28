import React from 'react';

interface Props {
  page: number;
  setPage: (page: number) => void;
  paginationCount: number;
  totalBlogs: number;
  blogsPerPage: number;
}

export const Pagination: React.FC<Props> = ({
  page,
  setPage,
  paginationCount,
  totalBlogs,
  blogsPerPage,
}) => {
  const totalPages = Math.ceil(totalBlogs / blogsPerPage);

  const getPageNumbers = () => {
    const middlePage = Math.ceil(paginationCount / 2);
    const startPage = Math.max(page - middlePage + 1, 1);
    const endPage = Math.min(startPage + paginationCount - 1, totalPages);

    return Array.from({ length: endPage - startPage + 1 }, (_, index) => startPage + index);
  };

  const updatePage = (num: number) => {
    setPage(num);
  };

  const pageNumbers = getPageNumbers();

  return (
    <div className="w-full flex justify-center mb-20">
      <div className="flex flex-wrap gap-4">
        {pageNumbers.map((num) => (
          <span
            key={num}
            onClick={() => updatePage(num)}
            className={`flex justify-center items-center h-10 w-10 font-bold font-primaryFont bg-slate-300 rounded-lg cursor-pointer ${
              num === page ? '!bg-blue-800 text-white' : ''
            }`}
          >
            {num}
          </span>
        ))}
      </div>
    </div>
  );
};

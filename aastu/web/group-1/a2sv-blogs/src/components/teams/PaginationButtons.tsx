import React from "react";

interface PaginationButtonProps {
  currentPage: number;
  totalPages: number;
  setCurrentPage: (page: number) => void;
}

const PaginationButtons: React.FC<PaginationButtonProps> = ({ currentPage, totalPages, setCurrentPage }) => {

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className="flex justify-center space-x-2 font-poppins font-semibold text-sm leading-5 text-center pt-1 mt-4">
      {Array.from({ length: totalPages }, (_, index) => (
        <div
          key={index + 1}
          className={bg-${currentPage === index + 1 ? "blue-700" : "white"} w-[40px] h-[40px] text-white rounded-[8px] shadow-md px-2 py-[11px]}
          onClick={() => handlePageChange(index + 1)}
        >
          {index + 1}
        </div>
      ))}
    </div>
  );
};

export default PaginationButtons;
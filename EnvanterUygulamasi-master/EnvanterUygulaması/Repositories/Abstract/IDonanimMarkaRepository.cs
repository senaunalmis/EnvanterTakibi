﻿using EnvanterUygulaması.Models;

namespace EnvanterUygulaması.Repositories.Abstract
{
    public interface IDonanimMarkaRepository: IGenericRepository<DonanimMarkalari>
    {
        Task<List<DonanimMarkalari>> TumunuGetirInclude();

    }
}

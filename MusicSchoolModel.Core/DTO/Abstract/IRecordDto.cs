namespace MusicSchoolModel.Core.DataTransfer.Abstract;

public interface IRecordDto
{
    public long Id { get; set; }
}

public interface IFullDto: IRecordDto { }

public interface IShortDto: IRecordDto { }
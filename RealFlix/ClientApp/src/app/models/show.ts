import { Genre } from './enums';

export class Show {
  Id: number;
  Url: string;
  Name: string;
  Type: string;
  Language: string;
  Genres: string;
  Status: string;
  Runtime: number;
  Premiered: Date;
  OfficialSite: string;
  ScheduledTime: string;
  ScheduledDays: string;
  RatingAverage: number;
  Weight: number;
  NetworkId: number;
  NetworkName: string;
  NetworkCountryName: string;
  NetworkCountryCode: string;
  WebChannel: string;
  ExternalsTvrage: number;
  ExternalsThetvdb: number;
  ExternalsImdb: number;
  ImageMedium: string;
  ImageOriginal: string;
  Summary: string;
  Updated: Date;
  LinksSelfHref: string;
  LinksPreviousEpisodeHref: string;
  LinksNextEpisodeHref: string;
  KeyWords: string;
}
